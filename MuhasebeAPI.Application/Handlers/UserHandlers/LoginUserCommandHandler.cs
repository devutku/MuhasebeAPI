using MediatR;
using MuhasebeAPI.Application.Commands.UserCommands;
using MuhasebeAPI.Application.Interfaces;
using MuhasebeAPI.Application.DTOs;
using MuhasebeAPI.Domain.Entities;

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
            var userType = request.PhoneNumber.StartsWith("B") ? UserType.BackOffice : UserType.Customer;
            var phoneNumber = request.PhoneNumber.Substring(1);
            var dto = new LoginRequest
            {
                PhoneNumber = phoneNumber,
                Password = request.Password,
                UserType = userType
            };

            return await _userService.LoginAsync(dto);
        }
    }
} 