using Dionisio.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dionisio.Domain.Entities
{
    public class PdfEntity : BaseEntity
    {
        public string NumeroLei { get; set; }
        public string Data { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
        public string Vigencia { get; set; }
        public string PdfFile { get; set; }
        public string FileHtml { get; set; }
    }
}
