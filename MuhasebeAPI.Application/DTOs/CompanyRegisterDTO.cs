using System.ComponentModel.DataAnnotations;

namespace MuhasebeAPI.Application.DTOs
{
    public class CompanyRegisterDto
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = null!;
        
        [Required]
        [StringLength(50)]
        public string taxNumber { get; set; } = null!;
    }
}
