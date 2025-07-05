using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Domain.Interfaces
{
    public interface IUserCompanyRepository : IBaseRepository<UserCompany>
    {
        Task<IEnumerable<UserCompany>> GetByUserIdAsync(Guid userId);
    }
}
