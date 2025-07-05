using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Domain.Entities;
using MuhasebeAPI.Domain.Interfaces;
using MuhasebeAPI.Infrastructure.Persistence;

namespace MuhasebeAPI.Infrastructure.Repositories
{
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Invoice?> GetByIdWithDetailsAsync(Guid id)
        {
            return await _dbSet
                .Include(i => i.InvoiceItems)
                    .ThenInclude(ii => ii.Stock)
                .Include(i => i.Account)
                .Include(i => i.Company)
                .FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted);
        }

        public async Task<IEnumerable<Invoice>> GetAllWithDetailsAsync()
        {
            return await _dbSet
                .Include(i => i.InvoiceItems)
                .Where(i => !i.IsDeleted)
                .ToListAsync();
        }
    }
}
