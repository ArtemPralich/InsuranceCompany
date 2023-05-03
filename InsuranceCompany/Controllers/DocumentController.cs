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
        public ActionResult GeneratePDF()
        {
            string htmlString = "<html><body><h1>Hello, world!</h1></body></html>";

            MemoryStream memoryStream = new MemoryStream();
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            document.Open();
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, new StringReader(htmlString));
            document.Close();

            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();

            return File(bytes, "application/pdf", "file.pdf");
        }

        [HttpGet]
        [Route("GetPDFs")]
        public async Task<ActionResult> GeneratePDFs()
        {
            // var engine = new RazorLightEngineBuilder()

            //.UseEmbeddedResourcesProject(typeof(ViewModel))
            //.SetOperatingAssembly(typeof(ViewModel).Assembly)
            //.UseMemoryCachingProvider()
            //.Build();

            // string template = "Hello, @Model.Cost. Welcome to RazorLight repository";
            // ViewModel model = new ViewModel { Cost = 10 };

            // string result = await engine.CompileRenderStringAsync("templateKey", template, model);
            // return Ok(result);

            var template = _repositoryManager.Template.FindAll(false).FirstOrDefault();
             var engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(InsuranceRequestDto))
                .UseMemoryCachingProvider()
                .Build();

             InsuranceRequestDto model = new InsuranceRequestDto { Cost = 10 };

            string result = await engine.CompileRenderStringAsync("templateKey", template.Text, model);

            MemoryStream memoryStream = new MemoryStream();
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            document.Open();
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, new StringReader(result));
            document.Close();

            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();

            return File(bytes, "application/pdf", $"{template.Title}.pdf");
        }


        [HttpGet(Name = "GetTemplate")]
        public IActionResult Get()
        {
            var clients = _repositoryManager.Template.GetAll(false).ToList();
            return Ok(clients);
        }

        [HttpPost(Name = "CreateTemplate")]
        public IActionResult Create(CreateTemplate insuranceRateDto)
        {
            var template = _mapper.Map<Template>(insuranceRateDto);
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
            _mapper.Map(templateDto, template);
            template.Text = template.Text.Replace("&lt;", "<");
            template.Text = template.Text.Replace("&gt;", ">");
            _repositoryManager.Template.Update(template);
            _repositoryManager.Save();
            return NoContent();
        }

        public class ViewModel
        {
            public int Cost { get; set; }
        }
    }

    public class InsuranceRequestHtmlTemplate
    {
        public InsuranceRequest Model { get; set; }
        public int Cost { get; set; }

        public string Html { get; set; }
    }
}
