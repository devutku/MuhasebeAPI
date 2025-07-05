using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Domain.Entities;
using MuhasebeAPI.Domain.Interfaces;
using MuhasebeAPI.Infrastructure.Persistence;

namespace MuhasebeAPI.Infrastructure.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _context;

        public StockRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public void Update(Stock stock)
        {
            _context.Stocks.Update(stock);
        }

        public void Delete(Stock stock)
        {
            _context.Stocks.Remove(stock);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Stock> stocks)
        {
            await _context.Stocks.AddRangeAsync(stocks);
        }

        public async Task<IEnumerable<Stock>> GetStocksByCompanyIdAsync(int companyId)
        {
            return await _context.Stocks
                .Where(s => s.CompanyId == companyId)
                .ToListAsync();
        }
    }
}
