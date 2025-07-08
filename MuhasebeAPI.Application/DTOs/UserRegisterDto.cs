using System.ComponentModel.DataAnnotations;

namespace MuhasebeAPI.Application.DTOs
{
    public class UserRegisterDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = null!;
    }
}
