using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Application.Commands.CompanyCommands;
using MuhasebeAPI.Application.Queries.CompanyQueries;
using MuhasebeAPI.Extensions;

namespace MuhasebeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCompaniesQuery();
            var companies = await _mediator.Send(query);
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var command = new GetCompanyByIdCommand { Id = id };
            var company = await _mediator.Send(command);
            if (company == null)
                return NotFound();

            return Ok(company);
        }

        [HttpGet("owner/{userId}")]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            var command = new GetCompaniesByOwnerCommand { UserId = userId };
            var companies = await _mediator.Send(command);
            return Ok(companies);
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyCommand command)
        {
            try
            {
                command.UserId = User.GetUserId();
                var company = await _mediator.Send(command);

                return Ok(new
                {
                    company.Id,
                    company.Name,
                    company.TaxNumber,
                    company.UserId,
                    Accounts = company.Accounts.Select(a => new
                    {
                        a.Id,
                        a.Name,
                        a.AccountCategoryId,
                        AccountCategoryName = a.AccountCategory.Name,
                        a.CompanyId
                    })
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] UpdateCompanyCommand command)
        {
            try
            {
                Guid userId = User.GetUserId();

                var getCompanyCommand = new GetCompanyByIdCommand { Id = id };
                var company = await _mediator.Send(getCompanyCommand);
                if (company == null)
                    return NotFound();

                if (company.UserId != userId)
                    return Forbid("You are not authorized to update this company.");

                command.Id = id;
                var updatedCompany = await _mediator.Send(command);
                return Ok(updatedCompany);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCompanyCommand { Id = id };
            bool deleted = await _mediator.Send(command);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
