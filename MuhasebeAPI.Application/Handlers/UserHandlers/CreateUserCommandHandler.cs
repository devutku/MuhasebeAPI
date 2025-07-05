using MediatR;
using MuhasebeAPI.Application.Commands.UserCommands;
using MuhasebeAPI.Application.Interfaces;
using MuhasebeAPI.Application.DTOs;

namespace MuhasebeAPI.Application.Handlers.UserHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var dto = new UserRegisterDto
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password
            };

            var result = await _userService.RegisterAsync(dto);
            return result ?? "Registration failed";
        }
    }
} 