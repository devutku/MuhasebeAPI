using MuhasebeAPI.Application.DTOs;
using MuhasebeAPI.Application.Interfaces;
using MuhasebeAPI.Domain.Entities;
using MuhasebeAPI.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace MuhasebeAPI.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IJwtService jwtService, IPasswordHasher passwordHasher, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        public async Task<string?> RegisterAsync(UserRegisterDto dto)
        {
            var existingUser = await _userRepository.GetByPhoneAndTypeAsync(dto.PhoneNumber, dto.UserType);
            if (existingUser != null)
            {
                _logger.LogWarning($"User registration failed: Phone {dto.PhoneNumber} with type {dto.UserType} already exists");
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
                _logger.LogInformation($"User registered successfully: {user.Email} with ID {user.Id}");
                return "User registered successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error registering user: {ex.Message}");
                throw;
            }
        }

        public async Task<string?> LoginAsync(LoginRequest dto)
        {
            var user = await _userRepository.GetByPhoneAndTypeAsync(dto.PhoneNumber, dto.UserType);
            if (user == null)
            {
                _logger.LogWarning("User not found.");
                return null;
            }

            if (!_passwordHasher.VerifyPassword(dto.Password, user.PasswordHash))
            {
                _logger.LogWarning("Invalid password.");
                return null;
            }

            var token = _jwtService.GenerateToken(user);
            if (token == null)
            {
                _logger.LogError("Token generation failed.");
                return null;
            }

            return token;
        }
    }

}
