using MediatR;
using MuhasebeAPI.Application.Queries.CompanyQueries;
using MuhasebeAPI.Application.Interfaces;

namespace MuhasebeAPI.Application.Handlers.CompanyHandlers
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, List<Domain.Entities.Company>>
    {
        private readonly ICompanyService _companyService;

        public GetAllCompaniesQueryHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<List<Domain.Entities.Company>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            return await _companyService.GetAllCompaniesAsync();
        }
    }
} 