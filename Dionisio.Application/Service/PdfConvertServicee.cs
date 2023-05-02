using Microsoft.AspNetCore.Http;
using PdfRepresantation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dionisio.Application.Service
{
    public class PdfConvertServicee
    {
        public string PdfToHtml(IFormFile file)
        {
            string result = "";
            var caminhoCompleto = $"{AppDomain.CurrentDomain.BaseDirectory}/temp/{Guid.NewGuid().ToString()}-{file.FileName}";
            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                file.CopyTo(stream);
                PdfDetails pdf = PdfDetailsFactory.Create(caminhoCompleto);
                result = new PdfHtmlWriter().ConvertPdf(pdf);
            };          
            return result;
        }
    }
}
