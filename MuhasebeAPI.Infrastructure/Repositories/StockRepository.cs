using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Domain.Entities;
using MuhasebeAPI.Domain.Interfaces;
using MuhasebeAPI.Infrastructure.Persistence;

namespace MuhasebeAPI.Infrastructure.Repositories
{
    public class StockRepository : BaseRepository<Stock>, IStockRepository
    {
        public StockRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Stock>> GetStocksByCompanyIdAsync(Guid companyId)
        {
            return await _dbSet
                .Where(s => s.CompanyId == companyId && !s.IsDeleted)
                .ToListAsync();
        }
    }
}
