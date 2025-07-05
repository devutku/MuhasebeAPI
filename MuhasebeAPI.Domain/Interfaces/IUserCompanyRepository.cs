using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Domain.Interfaces
{
    public interface IUserCompanyRepository
    {
        Task AddAsync(UserCompany userCompany);
        Task<IEnumerable<UserCompany>> GetByUserIdAsync(int userId);
        Task SaveChangesAsync();
    }
}
