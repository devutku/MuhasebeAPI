using MediatR;
using MuhasebeAPI.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MuhasebeAPI.Application.Commands.CompanyCommands
{
    public class CreateCompanyCommand : IRequest<Company>
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = null!;
        
        [Required]
        [StringLength(50)]
        public string TaxNumber { get; set; } = null!;
        
        // This will be set by the controller, not by the client
        public Guid OwnerId { get; set; }
    }
} 