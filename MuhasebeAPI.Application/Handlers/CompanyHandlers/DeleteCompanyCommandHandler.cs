using MediatR;
using MuhasebeAPI.Application.Commands.CompanyCommands;
using MuhasebeAPI.Application.Interfaces;

namespace MuhasebeAPI.Application.Handlers.CompanyHandlers
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, bool>
    {
        private readonly ICompanyService _companyService;

        public DeleteCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<bool> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            return await _companyService.DeleteCompanyAsync(request.Id);
        }
    }
} 