using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Domain.Entities;
using MuhasebeAPI.Domain.Interfaces;
using MuhasebeAPI.Infrastructure.Persistence;

namespace MuhasebeAPI.Infrastructure.Repositories
{
    public class UserCompanyRepository : IUserCompanyRepository
    {
        private readonly AppDbContext _context;

        public UserCompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserCompany userCompany)
        {
            await _context.UserCompanies.AddAsync(userCompany);
        }

        public async Task<IEnumerable<UserCompany>> GetByUserIdAsync(int userId)
        {
            return await _context.UserCompanies
                .Where(uc => uc.UserId == userId)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
