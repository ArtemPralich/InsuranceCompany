using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Microsoft.AspNetCore.Mvc;
using iTextSharp.text;
using InsuranceCompany.Infrastructure;
using InsuranceCompany.Core;
using InsuranceCompany.Shared.ModelDto.Create;
using InsuranceCompany.Core.Models;
using AutoMapper;
using InsuranceCompany.Shared.ModelDto.Update;
using InsuranceCompany.Shared.ModelDto;
using RazorLight;
using System.Reflection;
using Org.BouncyCastle.Asn1.Ocsp;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Hosting.Server;

namespace InsuranceCompany.Controllers
{
    [Route("[controller]")]
    public class DocumentController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IRepositoryManager _repositoryManager;

        private readonly IMapper _mapper;

        public DocumentController(ILogger<ClientController> logger, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetPDF")]
        public ActionResult GeneratePDF(Guid id)
        {
            var file = _repositoryManager.Document.GetById(id, false);
            if (file != null)
            {
                if (!System.IO.File.Exists(Path.Combine(file.Path, file.Title)))
                {
                    return NotFound(); // Если файл не найден, вернуть код 404 Not Found
                }

                var fileStream = new FileStream(Path.Combine(file.Path, file.Title), FileMode.Open); // Открыть поток файла

                var response = new FileStreamResult(fileStream, "application/pdf"); // Создать ответ HTTP с потоком файла и MIME типом "application/pdf"

                response.FileDownloadName = "file.Title"; // Название файла для скачивания

                return response;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("CreateDocuments")]
        public async Task<ActionResult> GeneratePDFs(Guid id)
        {
            var insurance = _repositoryManager.InsuranceRequest.GetById(id, false);
            List<Template> templates = new List<Template>();
            if(insurance != null && insurance.InsuranceRate != null)
            {
                templates = insurance.InsuranceRate.InsuranceRateTemplates.Select(x => x.Template).ToList();
            }
            var engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(InsuranceRequestDto))
                .UseMemoryCachingProvider()
                .Build();
            var mainInsuredPerson = insurance.InsuredPersons.FirstOrDefault(ip => ip.IsMainInsuredPerson);
            foreach(var template in templates)
            {
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
                string fileName = $"{template.Title}_{ mainInsuredPerson.Client.PersonalCode ?? "notFound"}.pdf";
                string filePath = AppDomain.CurrentDomain.BaseDirectory + $"\\{mainInsuredPerson.Client.PersonalCode ?? "notFound"}\\";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                _repositoryManager.Document.Create(new Core.Document() { InsuranceRequestId = insurance.Id, TemplateId = template.Id, Title = fileName, Path = filePath});
                // Сохраняем файл на диск
                System.IO.File.WriteAllBytes(Path.Combine(filePath, fileName), fileBytes);
            }
            _repositoryManager.Save();


            return Ok();
        }


        [HttpGet(Name = "GetTemplate")]
        public IActionResult Get()
        {
            var templates = _repositoryManager.Template.GetAll(false).ToList();
            var templatesDro = _mapper.Map<List<TemplateDto>>(templates);
            return Ok(templatesDro);
        }

        [HttpPost(Name = "CreateTemplate")]
        public IActionResult Create([FromBody]CreateTemplate insuranceRateDto)
        {
            var template = _mapper.Map<Template>(insuranceRateDto);
            foreach (var rate in insuranceRateDto.InsuranceRates)
            {
                template.InsuranceRateTemplates.Add(new InsuranceRateTemplate { InsuranceRateId = rate });
            }
            template.Text = template.Text.Replace("&lt;", "<");
            template.Text = template.Text.Replace("&gt;", ">");
            _repositoryManager.Template.Create(template);
            _repositoryManager.Save();
            return NoContent();
        }

        [HttpPut(Name = "UpdateTemplate")]
        public IActionResult Update([FromBody] UpdateTemplate templateDto)
        {

            var template = _repositoryManager.Template.GetById(templateDto.Id, true);
            List<InsuranceRateTemplate> insuranceRateTemplatesForAdd = new List<InsuranceRateTemplate>();
            List<InsuranceRateTemplate> insuranceRateTemplatesForDelete = new List<InsuranceRateTemplate>();
            foreach (var rate in templateDto.InsuranceRates)
            {
                if(template.InsuranceRateTemplates.FirstOrDefault(t => t.Id == rate) == null)
                {
                    insuranceRateTemplatesForAdd.Add(new InsuranceRateTemplate() { TemplateId = template.Id, InsuranceRateId = rate });
                }
            }

            insuranceRateTemplatesForDelete = template.InsuranceRateTemplates.Where(t => !templateDto.InsuranceRates.Contains(t.TemplateId)).ToList();

            _mapper.Map(templateDto, template);
            template.Text = template.Text.Replace("&lt;", "<");
            template.Text = template.Text.Replace("&gt;", ">");
            _repositoryManager.Template.Update(template);
            _repositoryManager.InsuranceRateTemplate.DeleteRange(insuranceRateTemplatesForDelete);
            _repositoryManager.InsuranceRateTemplate.CreateRange(insuranceRateTemplatesForAdd);
            
            _repositoryManager.Save();
            return NoContent();
        }

        [HttpDelete(Name = "DeleteTemplate")]
        public IActionResult Delete(Guid id)
        {

            var template = _repositoryManager.Template.GetById(id, true);
            _repositoryManager.Template.Delete(template);
            _repositoryManager.Save();
            return NoContent();
        }
    }
}
