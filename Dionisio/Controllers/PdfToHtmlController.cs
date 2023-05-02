using Dionisio.Application.Interface.Sevice;
using Dionisio.Application.Service;
using Dionisio.Domain.Entities;
using Dionisio.Domain.Models;
using Dionisio.PdfConverter;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1;

namespace Dionisio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PdfToHtmlController : ControllerBase
    {
        private readonly IPdfService _PdfService;

        public PdfToHtmlController(IPdfService PdfService)
        {
            _PdfService = PdfService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var res = await _PdfService.Get();
            return Ok(res);
        }

        [HttpGet("get/{id}")]
        public ActionResult<PdfEntity> GetPdfbyId(Guid id)
        {
            var Pdf = _PdfService.GetById(id);

            if (Pdf == null)
            {
                return BadRequest(new
                {
                    msg = "Não foi possível encontrar o Pdf!"
                });
            }

            return Ok(Pdf);
        }
        [HttpPost("add")]
        public async Task<ActionResult> AddPdf([FromForm] PdfModel Pdf)
        {           
            string FilePathPdf = Path.Combine("Storage", Pdf.PdfFile.FileName);
            string FilePathHtml = Path.Combine("Storage/ArquivosHtml", Pdf.PdfFile.FileName + ".html");

            using Stream fileStreamPdf = new FileStream(FilePathPdf, FileMode.Create);
            Pdf.PdfFile.CopyTo(fileStreamPdf);

            var htmlFile = PdfToHtml(Pdf.PdfFile);

            using StreamWriter HtmlWriter = new StreamWriter(FilePathHtml);
            HtmlWriter.Write(htmlFile);

            PdfEntity pdfEntity = new PdfEntity
            {
                Autor = Pdf.Autor,
                Data = Pdf.Data,
                Descricao = Pdf.Descricao,
                Vigencia = Pdf.Vigencia,
                PdfFile = FilePathPdf,
                FileHtml = FilePathHtml
            };

            var PdfCriado = await _PdfService.Add(pdfEntity);

            if (PdfCriado == null)
            {
                return BadRequest(new
                {
                    msg = "Não foi possível criar o Pdf!"
                });
            }

            return Ok(PdfCriado);
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateVeiculo(PdfEntity PdfAtualizado)
        {
            var PdfCriado = await _PdfService.Update(PdfAtualizado);

            if (PdfCriado == null)
            {
                return BadRequest(new
                {
                    msg = "Não foi possível editar o Pdf!"
                });
            }

            return Ok(PdfAtualizado);
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePdf(Guid id)
        {
            var PdfDeletado = await _PdfService.Delete(id);

            if (!PdfDeletado)
            {
                return BadRequest(new
                {
                    msg = "Não foi possível excluir o Pdf!"
                });
            }

            return Ok(PdfDeletado);
        }


        [HttpPost]
        public string PdfToHtml(IFormFile file)
        {

            return new PdfConvertService().PdfToHtml(file);
        }
    }
}
