using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);        // Email ile kullanıcı getir
        Task DeleteAsync(Guid id);                        // Kullanıcı sil
        Task<User?> GetByPhoneAsync(string areaCode, string phoneNumber); // Phone ile kullanıcı getir
    }
}
