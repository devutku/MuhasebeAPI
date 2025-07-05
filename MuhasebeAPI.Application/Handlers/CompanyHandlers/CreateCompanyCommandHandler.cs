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
            var dto = new CompanyRegisterDto
            {
                Name = request.Name,
                taxNumber = request.TaxNumber
            };

            return await _companyService.CreateCompanyAsync(dto, request.OwnerId);
        }
    }
} 