using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Domain.Entities;
using MuhasebeAPI.Domain.Interfaces;
using MuhasebeAPI.Infrastructure.Persistence;

namespace MuhasebeAPI.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);
        }

        public async Task<User?> GetByPhoneAsync(string areaCode, string phoneNumber)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.AreaCode == areaCode && u.PhoneNumber == phoneNumber && !u.IsDeleted);
        }

        public async Task<User?> GetByPhoneAndTypeAsync(string phoneNumber, UserType userType)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber && u.UserType == userType && !u.IsDeleted);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                Delete(user);
                await SaveChangesAsync();
            }
        }
    }
}
