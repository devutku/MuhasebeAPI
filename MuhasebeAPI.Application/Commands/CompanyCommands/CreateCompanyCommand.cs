using MediatR;
using MuhasebeAPI.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MuhasebeAPI.Application.Commands.CompanyCommands
{
    public class CreateCompanyCommand : IRequest<Company>
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = null!;
        
        public string? TaxNumber { get; set; }
        public string? TaxOffice { get; set; }
        public string? Address { get; set; }

        [JsonIgnore]
        public Guid UserId { get; set; }
    }
} 