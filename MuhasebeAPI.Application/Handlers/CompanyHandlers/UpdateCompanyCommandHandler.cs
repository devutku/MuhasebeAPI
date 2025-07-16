using MediatR;
using MuhasebeAPI.Application.Commands.CompanyCommands;
using MuhasebeAPI.Application.Interfaces;
using MuhasebeAPI.Application.DTOs;

namespace MuhasebeAPI.Application.Handlers.CompanyHandlers
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Domain.Entities.Company>
    {
        private readonly ICompanyService _companyService;

        public UpdateCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<Domain.Entities.Company> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var dto = new CompanyRegisterDto
            {
                Name = request.Name,
                TaxNumber = request.TaxNumber
            };

            return await _companyService.UpdateCompanyAsync(request.Id, dto);
        }
    }
} 