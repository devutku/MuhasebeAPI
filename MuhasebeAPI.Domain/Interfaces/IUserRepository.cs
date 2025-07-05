using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);                 // Id ile kullanıcı getir
        Task<User?> GetByEmailAsync(string email);        // Email ile kullanıcı getir
        Task AddAsync(User user);                          // Yeni kullanıcı ekle
        Task UpdateAsync(User user);                       // Kullanıcı güncelle
        Task DeleteAsync(int id);                          // Kullanıcı sil
        Task<IEnumerable<User>> GetAllAsync();             // Tüm kullanıcıları getir
    }
}
