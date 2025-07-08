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
        
        [Required]
        [StringLength(50)]
        public string TaxNumber { get; set; } = null!;

        [JsonIgnore]
        public Guid OwnerId { get; set; }
    }
} 