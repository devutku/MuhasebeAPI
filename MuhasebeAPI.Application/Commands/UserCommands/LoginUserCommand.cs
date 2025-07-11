using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MuhasebeAPI.Application.Commands.UserCommands
{
    public class LoginUserCommand : IRequest<string?>
    {
        [Required]
        [StringLength(10)]
        public string AreaCode { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; } = null!;
        
        [Required]
        public string Password { get; set; } = null!;
    }
} 