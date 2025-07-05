using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);        // Email ile kullanıcı getir
        Task DeleteAsync(Guid id);                        // Kullanıcı sil
    }
}
