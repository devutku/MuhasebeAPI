using MediatR;
using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Application.Commands.CompanyCommands
{
    public class GetCompaniesByOwnerCommand : IRequest<List<Company>>
    {
        public Guid UserId { get; set; }
    }
} 