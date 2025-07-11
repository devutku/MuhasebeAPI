using System.ComponentModel.DataAnnotations;

namespace MuhasebeAPI.Application.DTOs
{
    public class UserRegisterDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        
        [Required]
        [StringLength(10)]
        public string AreaCode { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; } = null!;
        
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = null!;

        [EmailAddress]
        public string? Email { get; set; }
    }
}
