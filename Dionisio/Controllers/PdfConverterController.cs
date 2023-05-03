using Dionisio.PdfConverter;
using Microsoft.AspNetCore.Mvc;

namespace Dionisio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PdfConverterController : Controller
    {
        [HttpPost]
        public string PdfToHtml(IFormFile file)
        {
            return new PdfConvertService().PdfToHtml(file);
        }
    }
}
