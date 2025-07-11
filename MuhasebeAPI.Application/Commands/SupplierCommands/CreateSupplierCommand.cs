using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MuhasebeAPI.Application.Commands.SupplierCommands
{
    public class CreateSupplierCommand : IRequest<Guid>
    {
        [Required]
        public string Name { get; set; } = null!;
        public string? TaxNumber { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
} 