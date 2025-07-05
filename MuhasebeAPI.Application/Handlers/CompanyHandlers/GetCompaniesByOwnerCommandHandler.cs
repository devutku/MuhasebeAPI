using MediatR;
using MuhasebeAPI.Application.Commands.CompanyCommands;
using MuhasebeAPI.Application.Interfaces;

namespace MuhasebeAPI.Application.Handlers.CompanyHandlers
{
    public class GetCompaniesByOwnerCommandHandler : IRequestHandler<GetCompaniesByOwnerCommand, List<Domain.Entities.Company>>
    {
        private readonly ICompanyService _companyService;

        public GetCompaniesByOwnerCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<List<Domain.Entities.Company>> Handle(GetCompaniesByOwnerCommand request, CancellationToken cancellationToken)
        {
            return await _companyService.GetCompaniesByOwnerIdAsync(request.OwnerId);
        }
    }
} 