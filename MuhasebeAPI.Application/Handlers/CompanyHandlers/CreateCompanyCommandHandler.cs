using MediatR;
using MuhasebeAPI.Application.Commands.CompanyCommands;
using MuhasebeAPI.Application.Interfaces;
using MuhasebeAPI.Application.DTOs;
using Microsoft.Extensions.Logging;

namespace MuhasebeAPI.Application.Handlers.CompanyHandlers
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Domain.Entities.Company>
    {
        private readonly ICompanyService _companyService;
        private readonly ILogger<CreateCompanyCommandHandler> _logger;

        public CreateCompanyCommandHandler(ICompanyService companyService, ILogger<CreateCompanyCommandHandler> logger)
        {
            _companyService = companyService;
            _logger = logger;
        }

        public async Task<Domain.Entities.Company> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var dto = new CompanyRegisterDto
            {
                Name = request.Name,
                TaxNumber = request.TaxNumber
            };

            _logger.LogInformation($"Creating company '{request.Name}' for user {request.UserId}");
            try
            {
                var company = await _companyService.CreateCompanyAsync(dto, request.UserId);
                _logger.LogInformation($"Company '{company.Name}' created successfully with ID {company.Id}");
                return company;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating company: {ex.Message}");
                throw;
            }
        }
    }
} 