using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dionisio.Domain.Models
{
    public class LawModel
    {
        public Guid Id { get; set; }
        public string NumeroLei { get; set; }
        public string Data { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
        public string Vigencia { get; set; }
        public IFormFile PdfFile { get; set; }
        public IFormFile? FileHtml { get; set; }
    }
}
