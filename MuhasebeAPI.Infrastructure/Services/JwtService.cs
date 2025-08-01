﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MuhasebeAPI.Application.Interfaces;
using MuhasebeAPI.Domain.Entities;
using MuhasebeAPI.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace MuhasebeAPI.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public JwtService(IPasswordHasher passwordHasher, IConfiguration configuration, IUserRepository userRepository)
        {
            _passwordHasher = passwordHasher;
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<User?> Authenticate(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email); 
            if (user == null) return null;

            bool isValid = _passwordHasher.VerifyPassword(password, user.PasswordHash);
            if (!isValid) return null;

            return user;
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                new Claim("UserType", user.UserType.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                signingCredentials: creds);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}
