using MediatR;
using MuhasebeAPI.Application.DTOs;

namespace MuhasebeAPI.Application.Commands.UserCommands
{
    public class CreateUserCommand : IRequest<string>
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
} 