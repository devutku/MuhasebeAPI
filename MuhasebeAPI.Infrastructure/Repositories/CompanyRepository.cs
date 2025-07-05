using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Domain.Entities;
using MuhasebeAPI.Domain.Interfaces;
using MuhasebeAPI.Infrastructure.Persistence;

namespace MuhasebeAPI.Infrastructure.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Company>> GetCompaniesByOwnerIdAsync(Guid ownerId)
        {
            return await _dbSet
                .Where(c => c.OwnerId == ownerId && !c.IsDeleted)
                .ToListAsync();
        }
    }
}
