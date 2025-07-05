using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Domain.Entities;
using MuhasebeAPI.Domain.Interfaces;
using MuhasebeAPI.Infrastructure.Persistence;

namespace MuhasebeAPI.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetCompaniesByOwnerIdAsync(int ownerId)
        {
            return await _context.Companies
                .Where(c => c.OwnerId == ownerId)
                .ToListAsync();
        }

        public void Update(Company company)
        {
            _context.Companies.Update(company);
        }

        public void Delete(Company company)
        {
            _context.Companies.Remove(company);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
