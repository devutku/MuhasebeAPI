using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Domain.Entities;
using MuhasebeAPI.Domain.Interfaces;
using MuhasebeAPI.Infrastructure.Persistence;

namespace MuhasebeAPI.Infrastructure.Repositories
{
    public class UserCompanyRepository : BaseRepository<UserCompany>, IUserCompanyRepository
    {
        public UserCompanyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserCompany>> GetByUserIdAsync(Guid userId)
        {
            return await _dbSet
                .Where(uc => uc.UserId == userId && !uc.IsDeleted)
                .ToListAsync();
        }
    }
}
