using System.ComponentModel.DataAnnotations;
using MuhasebeAPI.Domain.Entities;

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

        /// <summary>
        /// Phone number should start with 'B' or 'C' (e.g., B5xxxxxxxxx or C5xxxxxxxxx)
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; } = null!;
        
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = null!;

        [EmailAddress]
        public string? Email { get; set; }

        public UserType UserType { get; set; }
    }
}
