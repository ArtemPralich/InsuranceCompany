using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Microsoft.AspNetCore.Mvc;
using iTextSharp.text;

namespace InsuranceCompany.Controllers
{
    [Route("[controller]")]
    public class DocumentController : Controller
    {
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
    }
}
