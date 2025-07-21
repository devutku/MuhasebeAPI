using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Application.Commands.CompanyCommands;
using MuhasebeAPI.Application.Queries.CompanyQueries;
using MuhasebeAPI.Extensions;
using Microsoft.Extensions.Logging;

namespace MuhasebeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(IMediator mediator, ILogger<CompanyController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GetAll companies request received");
            var query = new GetAllCompaniesQuery();
            var companies = await _mediator.Send(query);
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation($"GetById company request for Id: {id}");
            var command = new GetCompanyByIdCommand { Id = id };
            var company = await _mediator.Send(command);
            if (company == null)
            {
                _logger.LogWarning($"Company not found: {id}");
                return NotFound();
            }

            return Ok(company);
        }

        [HttpGet("owner/{userId}")]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            _logger.LogInformation($"GetByUserId companies request for UserId: {userId}");
            var command = new GetCompaniesByOwnerCommand { UserId = userId };
            var companies = await _mediator.Send(command);
            return Ok(companies);
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateCompany([FromForm] CreateCompanyCommand command)
        {
            try
            {
                _logger.LogInformation("CreateCompany request received");
                if (User.GetUserType() != "BackOffice")
                {
                    _logger.LogWarning("Forbidden: Only BackOffice users can create companies.");
                    return StatusCode(403, "Only BackOffice users can create companies.");
                }
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
                        a.CompanyId
                    })
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(ex, "Unauthorized access in CreateCompany");
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromForm] UpdateCompanyCommand command)
        {
            try
            {
                _logger.LogInformation($"UpdateCompany request for Id: {id}");
                if (User.GetUserType() != "BackOffice")
                {
                    _logger.LogWarning("Forbidden: Only BackOffice users can update companies.");
                    return StatusCode(403, "Only BackOffice users can update companies.");
                }
                Guid userId = User.GetUserId();

                var getCompanyCommand = new GetCompanyByIdCommand { Id = id };
                var company = await _mediator.Send(getCompanyCommand);
                if (company == null)
                {
                    _logger.LogWarning($"Company not found for update: {id}");
                    return NotFound();
                }

                if (company.UserId != userId)
                {
                    _logger.LogWarning($"Forbidden: User {userId} not authorized to update company {id}");
                    return StatusCode(403, "You are not authorized to update this company.");
                }

                command.Id = id;
                var updatedCompany = await _mediator.Send(command);
                return Ok(updatedCompany);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(ex, "Unauthorized access in UpdateCompany");
                return Unauthorized(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation($"Delete company request for Id: {id}");
            if (User.GetUserType() != "BackOffice")
            {
                _logger.LogWarning("Forbidden: Only BackOffice users can delete companies.");
                return StatusCode(403, "Only BackOffice users can delete companies.");
            }
            var command = new DeleteCompanyCommand { Id = id };
            bool deleted = await _mediator.Send(command);
            if (!deleted)
            {
                _logger.LogWarning($"Company not found for delete: {id}");
                return NotFound();
            }

            return NoContent();
        }
    }
}
