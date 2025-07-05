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
namespace MuhasebeAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
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
        public InvoiceController(IInvoiceService invoiceService, ICompanyRepository companyRepository, AppDbContext context)
        {
            _invoiceService = invoiceService;
            _companyRepository = companyRepository;
            _context = context;
        }

        // Fatura oluşturma
        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice([FromForm] InvoiceDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("User not authenticated.");

            int userId = int.Parse(userIdClaim.Value);

            try
            {
                var createdInvoice = await _invoiceService.CreateInvoiceAsync(dto, userId);
                return Ok(createdInvoice);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDto>> GetById(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("User not authenticated.");

            int userId = int.Parse(userIdClaim.Value);

            var invoice = await _invoiceService.GetByIdWithDetailsAsync(id);
            if (invoice == null)
                return NotFound();

            if (invoice.Company.OwnerId != userId)
                return Forbid("You are not authorized to view this invoice.");

            var dto = MapToDto(invoice);
            return Ok(dto);
        }


        // Fatura silme
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("User not authenticated.");

            int userId = int.Parse(userIdClaim.Value);

            var invoice = await _invoiceService.GetByIdWithDetailsAsync(id);
            if (invoice == null)
                return NotFound();

            if (invoice.Company.OwnerId != userId)
                return Forbid("You are not authorized to delete this invoice.");

            try
            {
                await _invoiceService.DeleteInvoiceAsync(id);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("my-invoices")]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetMyInvoices()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("UserId claim not found.");

            int userId = int.Parse(userIdClaim.Value);

            var userCompanies = await _companyRepository.GetCompaniesByOwnerIdAsync(userId);
            var companyIds = userCompanies.Select(c => c.Id).ToList();

            var invoices = await _context.Invoices
                .Where(i => companyIds.Contains(i.CompanyId))
                .Include(i => i.InvoiceItems)
                .ToListAsync();

            var invoiceDtos = invoices.Select(i => MapToDto(i)).ToList();

            return Ok(invoiceDtos);
        }

    }
}
