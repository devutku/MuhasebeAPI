using MediatR;
using MuhasebeAPI.Application.Commands.CompanyCommands;
using MuhasebeAPI.Application.Interfaces;

namespace MuhasebeAPI.Application.Handlers.CompanyHandlers
{
    public class GetCompanyByIdCommandHandler : IRequestHandler<GetCompanyByIdCommand, Domain.Entities.Company?>
    {
        private readonly ICompanyService _companyService;

        public GetCompanyByIdCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<Domain.Entities.Company?> Handle(GetCompanyByIdCommand request, CancellationToken cancellationToken)
        {
            return await _companyService.GetCompanyByIdAsync(request.Id);
        }
    }
} 