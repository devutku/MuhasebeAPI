using MediatR;

namespace MuhasebeAPI.Application.Commands.UserCommands
{
    public class LoginUserCommand : IRequest<string?>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
} 