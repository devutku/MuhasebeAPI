using MediatR;
using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Application.Commands.CompanyCommands
{
    public class GetCompanyByIdCommand : IRequest<Company?>
    {
        public Guid Id { get; set; }
    }
} 