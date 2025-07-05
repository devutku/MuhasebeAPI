using MediatR;
using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Application.Commands.CompanyCommands
{
    public class CreateCompanyCommand : IRequest<Company>
    {
        public string Name { get; set; } = null!;
        public string TaxNumber { get; set; } = null!;
        public Guid OwnerId { get; set; }
    }
} 