using MediatR;
using MuhasebeAPI.Application.Commands.UserCommands;
using MuhasebeAPI.Application.Interfaces;
using MuhasebeAPI.Application.DTOs;

namespace MuhasebeAPI.Application.Handlers.UserHandlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string?>
    {
        private readonly IUserService _userService;

        public LoginUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var dto = new LoginRequest
            {
                Email = request.Email,
                Password = request.Password
            };

            return await _userService.LoginAsync(dto);
        }
    }
} 