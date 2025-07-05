using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Application.DTOs;
using MuhasebeAPI.Application.Interfaces;
using System.Security.Claims;

namespace MuhasebeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _companyService.GetAllCompaniesAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            if (company == null)
                return NotFound();

            return Ok(company);
        }

        [HttpGet("owner/{ownerId}")]
        public async Task<IActionResult> GetByOwnerId(int ownerId)
        {
            var companies = await _companyService.GetCompaniesByOwnerIdAsync(ownerId);
            return Ok(companies);
        }
        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateCompany([FromForm] CompanyRegisterDto dto)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("UserId claim not found.");

            int userId = int.Parse(userIdClaim.Value);

            var company = await _companyService.CreateCompanyAsync(dto, userId);

            return Ok(new
            {
                company.Id,
                company.Name,
                company.TaxNumber,
                Accounts = company.Accounts.Select(a => new
                {
                    a.Id,
                    a.Name,
                    a.Type,
                    a.CompanyId
                })
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, CompanyRegisterDto dto)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("UserId claim not found.");

            int userId = int.Parse(userIdClaim.Value);

            var company = await _companyService.GetCompanyByIdAsync(id);
            if (company == null)
                return NotFound();

            if (company.OwnerId != userId)
                return Forbid("You are not authorized to update this company.");

            var updatedCompany = await _companyService.UpdateCompanyAsync(id, dto);
            return Ok(updatedCompany);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _companyService.DeleteCompanyAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
