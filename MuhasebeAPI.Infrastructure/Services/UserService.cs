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

        public UserService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<string?> RegisterAsync(UserRegisterDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                Console.WriteLine($"User registration failed: Email {dto.Email} already exists");
                return null;
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                CreatedAt = DateTime.UtcNow
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
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null;
            Console.WriteLine("User authenticated successfully");
            return _jwtService.GenerateToken(user);
        }
    }

}
