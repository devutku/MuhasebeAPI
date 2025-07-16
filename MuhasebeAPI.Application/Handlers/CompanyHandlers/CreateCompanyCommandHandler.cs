using MediatR;
using MuhasebeAPI.Application.Commands.CompanyCommands;
using MuhasebeAPI.Application.Interfaces;
using MuhasebeAPI.Application.DTOs;

namespace MuhasebeAPI.Application.Handlers.CompanyHandlers
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Domain.Entities.Company>
    {
        private readonly ICompanyService _companyService;

        public CreateCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<Domain.Entities.Company> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Creating company '{request.Name}' for user {request.UserId}");
            
            var dto = new CompanyRegisterDto
            {
                Name = request.Name,
                TaxNumber = request.TaxNumber
            };

            try
            {
                var company = await _companyService.CreateCompanyAsync(dto, request.UserId);
                Console.WriteLine($"Company '{company.Name}' created successfully with ID {company.Id}");
                return company;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating company: {ex.Message}");
                throw;
            }
        }
    }
} 