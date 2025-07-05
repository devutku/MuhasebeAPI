using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        Task AddAsync(Company company);
        Task<Company?> GetByIdAsync(int id);
        Task<IEnumerable<Company>> GetAllAsync();
        Task<IEnumerable<Company>> GetCompaniesByOwnerIdAsync(int ownerId);
        void Update(Company company);
        void Delete(Company company);
        Task SaveChangesAsync();
    }
}
