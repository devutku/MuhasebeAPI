using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MuhasebeAPI.Application.Commands.UserCommands
{
    public class LoginUserCommand : IRequest<string?>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        
        [Required]
        public string Password { get; set; } = null!;
    }
} 