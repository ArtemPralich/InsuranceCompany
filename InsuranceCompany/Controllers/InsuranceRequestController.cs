using AutoMapper;
using InsuranceCompany.Core;
using InsuranceCompany.Core.Models;
using InsuranceCompany.Infrastructure;
using InsuranceCompany.Shared.ModelDto;
using InsuranceCompany.Shared.ModelDto.Create;
using InsuranceCompany.Shared.ModelDto.Update;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorLight;
using System.Text.Json;
using System.Text.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        [HttpGet("Validate", Name = "Validate")]
        public IActionResult Validate(Guid id)
        {
            var insuranceRequest = _repositoryManager.InsuranceRequest.GetById(id, false);
            if (insuranceRequest == null)
            {
                ModelState.TryAddModelError("request", "Страховой запрос не сохранен");
            }
            if (ModelState.ErrorCount > 0)
            {
                return BadRequest(ModelState);
            }

            return Ok();
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

        [HttpGet("MoveToApprove/{id}", Name = "MoveToApprove")]
        public async Task<IActionResult> MoveToApprove(Guid id)
        {
            var request = _repositoryManager.InsuranceRequest.GetById(id, true);
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

                MemoryStream memoryStream = new MemoryStream();
                iTextSharp.text.Document document = new iTextSharp.text.Document();
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                document.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, new StringReader(result));
                document.Close();

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
    }
}
 