using MediatR;

namespace MuhasebeAPI.Application.Commands.CompanyCommands
{
    public class DeleteCompanyCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
} 