using MuhasebeAPI.Application.DTOs;
using MuhasebeAPI.Application.Interfaces;
using MuhasebeAPI.Domain.Entities;
using MuhasebeAPI.Domain.Interfaces;

namespace MuhasebeAPI.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IJwtService jwtService, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
        }

        public async Task<string?> RegisterAsync(UserRegisterDto dto)
        {
            var existingUser = await _userRepository.GetByPhoneAndTypeAsync(dto.PhoneNumber, dto.UserType);
            if (existingUser != null)
            {
                Console.WriteLine($"User registration failed: Phone {dto.PhoneNumber} with type {dto.UserType} already exists");
                return null;
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                CreatedAt = DateTime.UtcNow,
                UserType = dto.UserType,
                AreaCode = dto.AreaCode
            };

            try
            {
                await _userRepository.AddAsync(user);
                await _userRepository.SaveChangesAsync();
                Console.WriteLine($"User registered successfully: {user.Email} with ID {user.Id}");
                return "User registered successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering user: {ex.Message}");
                throw;
            }
        }

        public async Task<string?> LoginAsync(LoginRequest dto)
        {
            var user = await _userRepository.GetByPhoneAndTypeAsync(dto.PhoneNumber, dto.UserType);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return null;
            }

            if (!_passwordHasher.VerifyPassword(dto.Password, user.PasswordHash))
            {
                Console.WriteLine("Invalid password.");
                return null;
            }

            var token = _jwtService.GenerateToken(user);
            if (token == null)
            {
                Console.WriteLine("Token generation failed.");
            }

            return token;
        }
    }

}
