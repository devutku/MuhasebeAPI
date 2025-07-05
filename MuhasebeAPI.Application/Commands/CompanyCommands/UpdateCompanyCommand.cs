using MediatR;
using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Application.Commands.CompanyCommands
{
    public class UpdateCompanyCommand : IRequest<Company>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string TaxNumber { get; set; } = null!;
    }
} 