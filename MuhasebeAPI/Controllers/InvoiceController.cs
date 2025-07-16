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

        public InvoiceController(IMediator mediator, ICompanyRepository companyRepository, AppDbContext context)
        {
            _mediator = mediator;
            _companyRepository = companyRepository;
            _context = context;
        }

        // Fatura oluşturma
        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice([FromForm] CreateInvoiceCommand command)
        {
            try
            {
                command.UserId = User.GetUserId();

                var createdInvoice = await _mediator.Send(command);
                return Ok(createdInvoice);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDto>> GetById(Guid id)
        {
            try
            {
                Guid userId = User.GetUserId();

                var query = new GetInvoiceByIdQuery { Id = id };
                var invoice = await _mediator.Send(query);
                if (invoice == null)
                    return NotFound();

                if (invoice.Company.UserId != userId)
                    return Forbid("You are not authorized to view this invoice.");

                var dto = MapToDto(invoice);
                return Ok(dto);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        // Fatura silme
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                Guid userId = User.GetUserId();

                var getInvoiceQuery = new GetInvoiceByIdQuery { Id = id };
                var invoice = await _mediator.Send(getInvoiceQuery);
                if (invoice == null)
                    return NotFound();

                if (invoice.Company.UserId != userId)
                    return Forbid("You are not authorized to delete this invoice.");

                var command = new DeleteInvoiceCommand { Id = id, UserId = userId };
                var result = await _mediator.Send(command);
                
                if (!result)
                    return BadRequest("Failed to delete invoice.");

                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("my-invoices")]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetMyInvoices()
        {
            try
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
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
