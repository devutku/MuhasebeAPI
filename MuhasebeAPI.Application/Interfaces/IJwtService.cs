using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Application.Interfaces
{
    public interface IJwtService
    {
        Task<User?> Authenticate(string email, string password);
        string GenerateToken(User user);
    }
}
