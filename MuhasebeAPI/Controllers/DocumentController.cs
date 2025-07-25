using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using MuhasebeAPI.Application.Interfaces;
using MuhasebeAPI.Application.Commands.DocumentCommands;
using MuhasebeAPI.Application.Queries.DocumentQueries;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MuhasebeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocumentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Upload a PDF document for a company.
        /// </summary>
        [Authorize(Roles = "BackOffice")]
        [HttpPost("{companyId:guid}/{documentType}")]
        public async Task<IActionResult> UploadDocument([FromRoute] Guid companyId, [FromRoute] DocumentType documentType, [FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");
            if (!file.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                return BadRequest("Only PDF files are allowed.");

            using (var stream = file.OpenReadStream())
            {
                var command = new UploadDocumentCommand(companyId, documentType, file.FileName, stream);
                await _mediator.Send(command);
            }
            return Ok("File uploaded successfully.");
        }

        /// <summary>
        /// Get a PDF document for a company.
        /// </summary>
        [Authorize(Roles = "BackOffice,Customer")]
        [HttpGet("{companyId:guid}/{documentType}")]
        public async Task<IActionResult> GetDocument([FromRoute] Guid companyId, [FromRoute] DocumentType documentType)
        {
            var query = new GetDocumentQuery(companyId, documentType);
            var stream = await _mediator.Send(query);
            if (stream == null)
                return NotFound();
            stream.Position = 0;
            return File(stream, "application/pdf");
        }

        /// <summary>
        /// Delete a PDF document for a company.
        /// </summary>
        [Authorize(Roles = "BackOffice")]
        [HttpDelete("{companyId:guid}/{documentType}")]
        public async Task<IActionResult> DeleteDocument([FromRoute] Guid companyId, [FromRoute] DocumentType documentType)
        {
            var command = new DeleteDocumentCommand(companyId, documentType);
            await _mediator.Send(command);
            return NoContent();
        }
    }
} 