using MediatR;
using MuhasebeAPI.Application.Commands.UserCommands;
using MuhasebeAPI.Application.Interfaces;
using MuhasebeAPI.Application.DTOs;
using MuhasebeAPI.Domain.Entities;

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
            
            var userType = request.PhoneNumber.StartsWith("B") ? UserType.BackOffice : UserType.Customer;
            var phoneNumber = request.PhoneNumber.Substring(1);
            var dto = new UserRegisterDto
            {
                Name = request.Name,
                PhoneNumber = phoneNumber,
                Password = request.Password,
                Email = request.Email,
                UserType = userType,
                AreaCode = request.AreaCode
            };

            var result = await _userService.RegisterAsync(dto);
            return result ?? "Email already registered";
        }
    }
} 