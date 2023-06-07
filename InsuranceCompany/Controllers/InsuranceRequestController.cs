using AngleSharp.Dom;
using AutoMapper;
using InsuranceCompany.Core;
using InsuranceCompany.Core.Models;
using InsuranceCompany.Infrastructure;
using InsuranceCompany.Shared.ModelDto;
using InsuranceCompany.Shared.ModelDto.Create;
using InsuranceCompany.Shared.ModelDto.Update;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using RazorLight;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Document = iTextSharp.text.Document;

namespace InsuranceCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceRequestController : ControllerBase
    {
        private readonly ILogger<InsuranceRequestController> _logger;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public InsuranceRequestController(ILogger<InsuranceRequestController> logger, IRepositoryManager repositoryManager,
            IMapper mapper, UserManager<User> userManager)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _userManager = userManager;
        }


        [HttpGet(Name = "GetInsuranceRequest")]
        public IActionResult Get()
        {
            var insuranceRequests = _repositoryManager.InsuranceRequest.GetAll(false);
            var insuranceRequestsDto = _mapper.Map<List<InsuranceRequestDto>>(insuranceRequests);

            return Ok(insuranceRequestsDto);
        }

        [HttpGet("{id}", Name = "GetInsuranceRequestById")]
        //[Authorize]
        public IActionResult GetById(Guid id)
        {
            var insuranceRequest = _repositoryManager.InsuranceRequest.GetById(id, false);
            var insuranceRequestsDto = _mapper.Map<InsuranceRequestDto>(insuranceRequest);
            foreach (var ins in insuranceRequestsDto.InsuranceRate.InsuranceTypeSurveys)
            {
                foreach (var question in ins.InsuranceSurvey.Questions)
                {
                    question.AnswerValues = question.AnswerValues.Where(q => q.InsuranceRequestId == insuranceRequest.Id).ToList();
                }
            }

            return Ok(insuranceRequestsDto);
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        [Route("GetClientInsurances")]
        public async Task<IActionResult> GetClientInsurances()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var insuredPeople = _repositoryManager.InsuredPerson.FindByCondition(p => p.ClientId == user.ClientId && p.IsMainInsuredPerson, false).Distinct().ToList();
            var ids = insuredPeople.Select(p => p.InsuranceRequestId).ToList();
            var requests = _repositoryManager.InsuranceRequest.FindByCondition(r => ids.Contains(r.Id), false)
                .Include(i => i.InsuranceRate).Include(i => i.InsuranceStatus).Include(i => i.Documents).Include(i => i.InsuredPersons).ThenInclude(p => p.Client).ToList();

            return Ok(requests);
        }

        [HttpPost(Name = "CreateInsuranceRequest")]
        public IActionResult Create(CreateInsuranceRequestDto insuranceRequestDto)
        {
            var insuranceRequest = _mapper.Map<InsuranceRequest>(insuranceRequestDto);
            var client = _mapper.Map<Client>(insuranceRequestDto.Client);
            insuranceRequest.InsuredPersons.Add(new Core.Models.InsuredPerson()
            {
                InsuranceRequest = insuranceRequest,
                Client = client,
                IsMainInsuredPerson = true
            });
            insuranceRequest.InsuranceStatus = _repositoryManager.InsuranceStatus.GetByStatus("Создано", true);

            var insRate = _repositoryManager.InsuranceRate.GetById(insuranceRequestDto.InsuranceRateId ?? Guid.NewGuid(), false);
            var rates = insRate.InsuranceTypeSurveys.ToList();
            foreach (var rate in rates)
            {
                if (rate.InsuranceSurvey.IsDeactivated ?? false)
                {
                    continue;
                }
                foreach (var questionSurvey in rate.InsuranceSurvey.QuestionSurveys)
                {
                    insuranceRequest.AnswerValues.Add(new AnswerValue()
                    {
                        QuestionId = questionSurvey.Question.Id,
                        InsuranceRequest = insuranceRequest,
                        InsuranceSurveyId = rate.InsuranceSurvey.Id,
                        Value = ""
                    });
                }
            }
            _repositoryManager.InsuranceRequest.Create(insuranceRequest);
            _repositoryManager.Save();

            return Ok(insuranceRequest.Id);
        }

        [HttpPost("CreateByClient", Name = "CreateClientInsuranceRequest")]
        //[Authorize(Roles = "Client")]
        public async Task<IActionResult> CreateByClient(CreateInsuranceRequestDto insuranceRequestDto)
        {
            var insuranceRequest = _mapper.Map<InsuranceRequest>(insuranceRequestDto);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var client = _repositoryManager.Client.GetById(user.ClientId ?? Guid.Empty, true);
            //_mapper.Map(insuranceRequestDto.Client, client);
            insuranceRequest.InsuredPersons.Add(new Core.Models.InsuredPerson()
            {
                InsuranceRequest = insuranceRequest,
                Client = client,
                IsMainInsuredPerson = true
            });
            insuranceRequest.InsuranceStatus = _repositoryManager.InsuranceStatus.GetByStatus("Создано клиентом", true);

            var insRate = _repositoryManager.InsuranceRate.GetById(insuranceRequestDto.InsuranceRateId ?? Guid.NewGuid(), false);
            var rates = insRate.InsuranceTypeSurveys.ToList();
            foreach (var rate in rates)
            {
                if (rate.InsuranceSurvey.IsDeactivated ?? false)
                {
                    continue;
                }
                foreach (var questionSurvey in rate.InsuranceSurvey.QuestionSurveys)
                {
                    insuranceRequest.AnswerValues.Add(new AnswerValue()
                    {
                        QuestionId = questionSurvey.Question.Id,
                        InsuranceRequest = insuranceRequest,
                        InsuranceSurveyId = rate.InsuranceSurvey.Id,
                        Value = ""
                    });
                }
            }
            _repositoryManager.InsuranceRequest.Create(insuranceRequest);
            _repositoryManager.Save();

            return Ok(insuranceRequest.Id);
        }

        [HttpGet("MoveToSign/{id}", Name = "MoveToSign")]
        public async Task<IActionResult> MoveToSign(Guid id)
        {
            var request = _repositoryManager.InsuranceRequest.GetById(id, true);
            request.InsuranceStatusId = new Guid("8CD43F71-1D6A-4A45-8974-6A4D9F6749ED");
            var client = request.InsuredPersons.Where(ip => ip.IsMainInsuredPerson).FirstOrDefault();
            var user = _userManager.Users.Where(u => u.ClientId == client.ClientId).FirstOrDefault();
            if (user == null)
            {
                var newUser = new User()
                {
                    FirstName = "",
                    LastName = "",
                    Email = client.Client.Email,
                    UserName = client.Client.Email,
                    ClientId = client.Client.Id
                };
                string password = "";
                {
                    Random random = new Random();
                    bool containsNumber = false;

                    while (!containsNumber || password.Length < 16)
                    {
                        password = "";
                        containsNumber = false;

                        for (int i = 0; i < 16; i++)
                        {
                            char c = (char)random.Next(33, 127); // генерируем случайный символ из ASCII таблицы
                            password += c;

                            if (char.IsNumber(c))
                            {
                                containsNumber = true;
                            }
                        }
                    }
                }
                var result = await _userManager.CreateAsync(newUser, password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRolesAsync(newUser, new List<string>() { "Client" });
                _repositoryManager.Email.SendEmailMessage(newUser.Email, "Ваш пароль", "Мы генерировали для вас новый пароль: " + password);
            }
            _repositoryManager.InsuranceRequest.Update(request);
            _repositoryManager.Save();
            return NoContent();
        }

        [HttpGet("TestDoc", Name = "TestDoc")]
        public ActionResult GeneratePDF()
        {
            string htmlCode = "<b>Привет мир</b>";

            // Создание PDF-документа
            Document document = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            // Загрузка шрифта Arial
            BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font font = new Font(baseFont, 12, Font.NORMAL);

            // Преобразование HTML в PDF
            XMLWorkerFontProvider fontProvider = new XMLWorkerFontProvider();
            fontProvider.Register("C:\\Windows\\Fonts\\arial.ttf", "Arial");
            CssAppliers cssAppliers = new CssAppliersImpl(fontProvider);
            HtmlPipelineContext htmlContext = new HtmlPipelineContext(cssAppliers);
            htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());
            ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(true);
            IPipeline pipeline = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));
            XMLWorker worker = new XMLWorker(pipeline, true);
            XMLParser parser = new XMLParser(worker);
            using (StringReader sr = new StringReader(htmlCode))
            {
                parser.Parse(sr);
            }

            // Закрытие документа
            document.Close();

            // Возвращение PDF-файла клиенту
            byte[] fileBytes = memoryStream.ToArray();
            memoryStream.Close();

            return File(fileBytes, "application/pdf", "output.pdf");
        }

        [HttpGet("MoveToApprove/{id}", Name = "MoveToApprove")]
        public async Task<IActionResult> MoveToApprove(Guid id)
        {
            var request = _repositoryManager.InsuranceRequest.GetById(id, true);
            var modelError = this.Validate(request);
            if(modelError.Count > 0)
            {
                return BadRequest(modelError);
            }
            request.InsuranceStatusId = new Guid("B74A9704-FF2C-4992-80B5-F22905091835");
            _repositoryManager.InsuranceRequest.Update(request);

            var insurance = _repositoryManager.InsuranceRequest.GetById(id, true);
            List<Template> templates = new List<Template>();
            if (insurance != null && insurance.InsuranceRate != null)
            {
                templates = insurance.InsuranceRate.InsuranceRateTemplates.Select(x => x.Template).ToList();
            }
            var mainInsuredPerson = insurance.InsuredPersons.FirstOrDefault(ip => ip.IsMainInsuredPerson);
            foreach (var template in templates)
            {
                var engine = new RazorLightEngineBuilder()
                    .UseEmbeddedResourcesProject(typeof(InsuranceRequestDto))
                    .UseMemoryCachingProvider()
                    .Build();

                string result = await engine.CompileRenderStringAsync("templateKey", template.Text, insurance);

                //MemoryStream memoryStream = new MemoryStream();
                //    iTextSharp.text.Document document = new iTextSharp.text.Document();
                //    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                //    document.Open();
                //    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, new StringReader(result));
                //    document.Close();

                // Создание PDF из HTML
                var renderer = new IronPdf.HtmlToPdf();
                var pdf = renderer.RenderHtmlAsPdf(result);

                // Получение байтового массива PDF-файла
                byte[] pdfBytes = pdf.BinaryData;

                // Запись байтового массива в MemoryStream
                MemoryStream memoryStream = new MemoryStream(pdfBytes);

                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                byte[] fileBytes = bytes;
                string fileName = $"{template.Title}_{mainInsuredPerson.Client.PersonalCode ?? "notFound"}.pdf";
                string filePath = AppDomain.CurrentDomain.BaseDirectory + $"\\{mainInsuredPerson.Client.PersonalCode ?? "notFound"}\\";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                _repositoryManager.Document.Create(new Core.Document() { InsuranceRequestId = insurance.Id, TemplateId = template.Id, Title = fileName, Path = filePath });
                // Сохраняем файл на диск
                System.IO.File.WriteAllBytes(Path.Combine(filePath, fileName), fileBytes);
            }
            insurance.IsReadyDocuments = true;
            _repositoryManager.InsuranceRequest.Update(insurance);
            _repositoryManager.Save();
            return NoContent();
        }

        [HttpGet("MoveToErrorState/{id}", Name = "MoveToErrorState")]
        public IActionResult MoveToErrorState(Guid id)
        {
            var request = _repositoryManager.InsuranceRequest.GetById(id, true);
            request.InsuranceStatusId = new Guid("9EAC0D43-CEB1-404C-85E2-D7C9303DFCD8");
            _repositoryManager.InsuranceRequest.Update(request);
            _repositoryManager.Save();
            _repositoryManager.Document.DeleteRange(request.Documents.ToList());
            _repositoryManager.Save();
            return NoContent();
        }

        [HttpPut(Name = "UpdateInsuranceRequest")]
        public IActionResult Update(UpdateInsuranceDto insuranceRequestDto)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true // optional for pretty-printing the JSON
            };

            var insuranceRequest = _repositoryManager.InsuranceRequest.GetByIdForCreate(insuranceRequestDto.Id, true);
            var json = JsonSerializer.Serialize(insuranceRequest, options);

            if (insuranceRequest == null)
            {
                return NotFound();
            }
            
            _mapper.Map(insuranceRequestDto, insuranceRequest);

            var json1 = JsonSerializer.Serialize(insuranceRequest, options);
            _repositoryManager.InsuranceRequest.Update(insuranceRequest);
            _repositoryManager.Save();


            if(insuranceRequest.InsuredPersons.Where(i => i.IsMainInsuredPerson).FirstOrDefault()?.ClientId 
                != insuranceRequestDto.InsuredPersons.Where(i => i.IsMainInsuredPerson).FirstOrDefault()?.Client.Id)
            {
                var insuranceReq = insuranceRequest.InsuredPersons.Where(i => i.IsMainInsuredPerson).FirstOrDefault();
                insuranceReq.ClientId = insuranceRequestDto.InsuredPersons.Where(i => i.IsMainInsuredPerson).FirstOrDefault()?.Client.Id;
            }


            var insuredPersonForCreate = insuranceRequestDto.InsuredPersons.Where(p => Guid.Empty.Equals(p.Id) || p.Id == null).ToList();
            foreach(var person in insuredPersonForCreate)
            {
                if(person.Client.PersonalCode == null)
                {
                    person.Client.PersonalCode = "";
                }
            }
            var insuredPersonForDelete = insuranceRequest.InsuredPersons.Where(p => !insuranceRequestDto.InsuredPersons.Select(pr => pr.Id).Contains(p.Id)).ToList();
            var insuredPersonForUpdate = _repositoryManager.InsuredPerson.GetRangeByIds(insuranceRequest.InsuredPersons.Select(x => x.Id).ToList(), true);

            foreach(var insuredPerson in insuredPersonForUpdate)
            {
                _mapper.Map(insuranceRequestDto.InsuredPersons.Where(i => i.Id.Equals(insuredPerson.Id)).FirstOrDefault(), insuredPerson);
            }

            var newPersons = _mapper.Map<List<InsuredPerson>>(insuredPersonForCreate);

            foreach (var person in newPersons)
            {
                if (person != null)
                {
                    person.InsuranceRequestId = insuranceRequestDto.Id;
                }
            }
            _repositoryManager.InsuredPerson.UpdateRange(insuredPersonForUpdate);
            _repositoryManager.InsuredPerson.CreateRange(newPersons);
            _repositoryManager.InsuredPerson.DeleteRange(insuredPersonForDelete);

            
            _repositoryManager.Save();

            return NoContent();
        }

        [HttpDelete(Name = "DeleteInsuranceRequest")]
        public IActionResult Delete(Guid insuranceRequestId)
        {
            var insuranceRequest = _repositoryManager.InsuranceRequest.GetById(insuranceRequestId, true);
            if (insuranceRequest == null)
            {
                return BadRequest();
            }

            _repositoryManager.InsuranceRequest.Delete(insuranceRequest);
            _repositoryManager.Save();
            return NoContent();
        }

        class Error
        {
            public string Key { get; set; }
            public string Value { get; set; }
            public string Page { get; set; }

        }
        private List<Error> Validate(InsuranceRequest insuranceRequest)
        {
            var error = new List<Error>();
            if (insuranceRequest == null)
            {
                //ModelState.TryAddModelError("request", "Страховой запрос не сохранен");
                error.Add(new Error() { Key = "", Value = "" });
            }
            else
            {
                var mainClient = insuranceRequest.InsuredPersons.Where(p => p.IsMainInsuredPerson).FirstOrDefault();
                bool isValidEmail = Regex.IsMatch(mainClient.Client.Email ?? "", @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                if (!isValidEmail)
                {
                    error.Add(new Error() { Key = "MainClient.Email", Value = "Некоректный email", Page = "1" });
                    //ModelState.TryAddModelError("InsuredPerson", "Некоректный email");
                }


                string pattern = "[A-Za-z]{2}\\d{7}";
                bool isMatch = Regex.IsMatch(mainClient.Client.PersonalCode ?? "", pattern);
                if (!isMatch)
                {
                    error.Add(new Error() { Key = "MainClient.PersonalCode", Value = "Некоректный персональный код", Page = "1" });
                }

                if (string.IsNullOrWhiteSpace(mainClient.Client.Name))
                {
                    error.Add(new Error() { Key = "MainClient.Name", Value = "Некоректное имя", Page = "1" });
                }
                if (string.IsNullOrWhiteSpace(mainClient.Client.Address))
                {
                    error.Add(new Error() { Key = "MainClient.Address", Value = "Некоректный адрес", Page = "1" });
                }
                if (mainClient.Client.Gender == null)
                {
                    error.Add(new Error() { Key = "MainClient.Gender", Value = "Некоректный гендер", Page = "1" });
                }
                if (string.IsNullOrWhiteSpace(mainClient.Client.PhoneNumber))
                {
                    error.Add(new Error() { Key = "MainClient.PhoneNumber", Value = "Некоректный номер телефона", Page = "1" });
                }
                if (string.IsNullOrWhiteSpace(mainClient.Client.Surname))
                {
                    error.Add(new Error() { Key = "MainClient.Surname", Value = "Некоректная фамилия", Page = "1" });
                }
                if (mainClient.Client.DateOfBirth == null)
                {
                    error.Add(new Error() { Key = "MainClient.DateOfBirth", Value = "Некоректная дата рождения", Page = "1" });
                }
                if(insuranceRequest.Benefits == null || insuranceRequest.Benefits <= 0)
                {
                    error.Add(new Error() { Key = "InsuranceRequest.Benefits", Value = "Некоректные бенефиты", Page = "1" });
                }

                string pattern1 = "[0-9]{3}";
                bool isMatch1 = Regex.IsMatch(insuranceRequest.CardCode ?? "", pattern1);
                if (!isMatch1)
                {
                    error.Add(new Error() { Key = "InsuranceRequest.CardCode", Value = "Некоректный код", Page = "3" });
                }

                string pattern2 = "[0-9]{2}/[0-9]{2}";
                bool isMatch2 = Regex.IsMatch(insuranceRequest.CardPeriod ?? "", pattern2);
                if (!isMatch2)
                {
                    error.Add(new Error() { Key = "InsuranceRequest.CardPeriod", Value = "Некоректный период", Page = "3" });
                }
                
                string pattern3 = "[0-9]{16}";
                bool isMatch3 = Regex.IsMatch(insuranceRequest.CardAccount ?? "" , pattern3);
                if (!isMatch3)
                {
                    error.Add(new Error() { Key = "InsuranceRequest.CardAccount", Value = "Некоректный номер карты", Page = "3" });
                }

                if (string.IsNullOrWhiteSpace(insuranceRequest.BankName))
                {
                    error.Add(new Error() { Key = "InsuranceRequest.BankName", Value = "Неправильно выбран банк", Page = "3" });
                }
            }
            return error;
        }
    }
}
 