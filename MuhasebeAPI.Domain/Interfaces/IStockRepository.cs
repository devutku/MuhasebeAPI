using MuhasebeAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuhasebeAPI.Domain.Interfaces
{
    public interface IStockRepository
    {
        Task AddAsync(Stock stock);
        Task AddRangeAsync(IEnumerable<Stock> stocks);
        Task<Stock?> GetByIdAsync(int id);
        Task<IEnumerable<Stock>> GetAllAsync();
        Task<IEnumerable<Stock>> GetStocksByCompanyIdAsync(int companyId);
        void Update(Stock stock);
        void Delete(Stock stock);
        Task SaveChangesAsync();
    }
}
