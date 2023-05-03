using Dionisio.Application.Interface.Sevice;
using Dionisio.Application.Service;
using Dionisio.Domain.Entities;
using Dionisio.Domain.Models;
using Dionisio.PdfConverter;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1;
using System.Net;
using System.Net.Http.Headers;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Dionisio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LawController : ControllerBase
    {
        private readonly ILawService _LawService;

        public LawController(ILawService LawService)
        {
            _LawService = LawService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var res = await _LawService.Get();
            return Ok(res);
        }

        [HttpGet("get/{id}")]
        public ActionResult<LawEntity> GetLawbyId(Guid id)
        {
            var Pdf = _LawService.GetById(id);

            if (Pdf == null)
            {
                return BadRequest(new
                {
                    msg = "Não foi possível encontrar a Lei!"
                });
            }

            return Ok(Pdf);
        }

        [HttpGet("getHtml/{id}")]
        public ActionResult<string> GetHtmlbyId(Guid id)
        {
            string FilePathHtml = Path.Combine("Storage/ArquivosHtml", id + ".html");

            //using StreamReader HtmlWriter = new(FilePathHtml);
            using var html = new StreamReader(FilePathHtml);
            var teste = html.ReadToEnd();
            //var html = File.ReadAllText(FilePathHtml);

            if (FilePathHtml == null)
            {
                return BadRequest(new
                {
                    msg = "Não foi possível encontrar o arquivo Html!"
                });
            }

            return Ok(teste);
        }

        [HttpGet("download-pdf")]
        public async Task<IActionResult> DownloadPdf(string filePath)
        {
            string nome = filePath.Substring(filePath.LastIndexOf('/') + 1);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);

            var content = new ByteArrayContent(fileBytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            return File(fileBytes, "application/pdf", $"{nome.Substring(36)}.pdf");
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddLaw([FromForm] LawModel Pdf)
        {           
            string FilePathPdf = Path.Combine("Storage", Guid.NewGuid().ToString() + Pdf.PdfFile.FileName);
            string FilePathHtml = Path.Combine("Storage/ArquivosHtml", Guid.NewGuid().ToString() + ".html");

            using Stream fileStreamPdf = new FileStream(FilePathPdf, FileMode.Create);
            Pdf.PdfFile.CopyTo(fileStreamPdf);

            var htmlFile = new PdfConvertService().PdfToHtml(Pdf.PdfFile);

            using StreamWriter HtmlWriter = new(FilePathHtml);
            HtmlWriter.Write(htmlFile);

            LawEntity pdfEntity = new()
            {
                Autor = Pdf.Autor,
                Data = Pdf.Data,
                Descricao = Pdf.Descricao,
                Vigencia = Pdf.Vigencia,
                PdfFile = FilePathPdf,
                FileHtml = FilePathHtml
            };

            var PdfCriado = await _LawService.Add(pdfEntity);

            if (PdfCriado == null)
            {
                return BadRequest(new
                {
                    msg = "Não foi possível criar a Lei!"
                });
            }

            return Ok(PdfCriado);
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateLaw(LawEntity PdfAtualizado)
        {
            var PdfCriado = await _LawService.Update(PdfAtualizado);

            if (PdfCriado == null)
            {
                return BadRequest(new
                {
                    msg = "Não foi possível editar o Lei!"
                });
            }

            return Ok(PdfAtualizado);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteLaw(Guid id)
        {
            var PdfDeletado = await _LawService.Delete(id);

            if (!PdfDeletado)
            {
                return BadRequest(new
                {
                    msg = "Não foi possível excluir a Lei!"
                });
            }

            return Ok(PdfDeletado);
        }


    }
}
