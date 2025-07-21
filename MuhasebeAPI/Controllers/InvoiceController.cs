using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Application.DTOs;
using MuhasebeAPI.Domain.Entities;
using MuhasebeAPI.Domain.Interfaces;
using MuhasebeAPI.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using MuhasebeAPI.Application.Commands.InvoiceCommands;
using MuhasebeAPI.Application.Queries.InvoiceQueries;
using MuhasebeAPI.Extensions;
using Microsoft.Extensions.Logging;

namespace MuhasebeAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InvoiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICompanyRepository _companyRepository;
        private readonly AppDbContext _context;
        private readonly ILogger<InvoiceController> _logger;

        private InvoiceDto MapToDto(Invoice invoice)
        {
            return new InvoiceDto
            {
                CompanyId = invoice.CompanyId,
                AccountId = invoice.AccountId,
                InvoiceType = invoice.InvoiceType,
                InvoiceDate = invoice.InvoiceDate,
                Items = invoice.InvoiceItems.Select(ii => new InvoiceItemDto
                {
                    StockId = ii.StockId,
                    Quantity = ii.Quantity,
                    UnitPrice = ii.UnitPrice,
                }).ToList()
            };
        }

        public InvoiceController(IMediator mediator, ICompanyRepository companyRepository, AppDbContext context, ILogger<InvoiceController> logger)
        {
            _mediator = mediator;
            _companyRepository = companyRepository;
            _context = context;
            _logger = logger;
        }

        // Fatura oluşturma
        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice([FromForm] CreateInvoiceCommand command)
        {
            try
            {
                _logger.LogInformation("CreateInvoice request received");
                if (User.GetUserType() != "BackOffice")
                {
                    _logger.LogWarning("Forbidden: Only BackOffice users can create invoices.");
                    return StatusCode(403, "Only BackOffice users can create invoices.");
                }
                command.UserId = User.GetUserId();
                var createdInvoice = await _mediator.Send(command);
                return Ok(createdInvoice);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(ex, "Unauthorized access in CreateInvoice");
                return Unauthorized(ex.Message);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error in CreateInvoice");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDto>> GetById(Guid id)
        {
            try
            {
                _logger.LogInformation($"GetById invoice request for Id: {id}");
                Guid userId = User.GetUserId();

                var query = new GetInvoiceByIdQuery { Id = id };
                var invoice = await _mediator.Send(query);
                if (invoice == null)
                {
                    _logger.LogWarning($"Invoice not found: {id}");
                    return NotFound();
                }

                if (invoice.Company.UserId != userId)
                {
                    _logger.LogWarning($"Forbidden: User {userId} not authorized to view invoice {id}");
                    return StatusCode(403, "You are not authorized to view this invoice.");
                }

                var dto = MapToDto(invoice);
                return Ok(dto);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(ex, "Unauthorized access in GetById");
                return Unauthorized(ex.Message);
            }
        }

        // Fatura silme
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                _logger.LogInformation($"Delete invoice request for Id: {id}");
                if (User.GetUserType() != "BackOffice")
                {
                    _logger.LogWarning("Forbidden: Only BackOffice users can delete invoices.");
                    return StatusCode(403, "Only BackOffice users can delete invoices.");
                }
                Guid userId = User.GetUserId();
                var getInvoiceQuery = new GetInvoiceByIdQuery { Id = id };
                var invoice = await _mediator.Send(getInvoiceQuery);
                if (invoice == null)
                {
                    _logger.LogWarning($"Invoice not found for delete: {id}");
                    return NotFound();
                }
                if (invoice.Company.UserId != userId)
                {
                    _logger.LogWarning($"Forbidden: User {userId} not authorized to delete invoice {id}");
                    return StatusCode(403, "You are not authorized to delete this invoice.");
                }
                var command = new DeleteInvoiceCommand { Id = id, UserId = userId };
                var result = await _mediator.Send(command);
                if (!result)
                {
                    _logger.LogWarning($"Failed to delete invoice: {id}");
                    return BadRequest("Failed to delete invoice.");
                }
                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(ex, "Unauthorized access in Delete");
                return Unauthorized(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("my-invoices")]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetMyInvoices()
        {
            try
            {
                _logger.LogInformation("GetMyInvoices request received");
                if (User.GetUserType() == "Customer")
                {
                    Guid userId = User.GetUserId();
                    var userCompanies = await _companyRepository.GetCompaniesByUserIdAsync(userId);
                    var companyIds = userCompanies.Select(c => c.Id).ToList();
                    var invoices = await _context.Invoices
                        .Where(i => companyIds.Contains(i.CompanyId))
                        .Include(i => i.InvoiceItems)
                        .ToListAsync();
                    var invoiceDtos = invoices.Select(i => MapToDto(i)).ToList();
                    return Ok(invoiceDtos);
                }
                else if (User.GetUserType() == "BackOffice")
                {
                    var invoices = await _context.Invoices.Include(i => i.InvoiceItems).ToListAsync();
                    var invoiceDtos = invoices.Select(i => MapToDto(i)).ToList();
                    return Ok(invoiceDtos);
                }
                else
                {
                    _logger.LogWarning("Unknown user type in GetMyInvoices");
                    return StatusCode(403, "Unknown user type.");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(ex, "Unauthorized access in GetMyInvoices");
                return Unauthorized(ex.Message);
            }
        }
    }
}
