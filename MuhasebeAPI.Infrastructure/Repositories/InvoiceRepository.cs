using Microsoft.EntityFrameworkCore;
using MuhasebeAPI.Domain.Entities;
using MuhasebeAPI.Domain.Interfaces;
using MuhasebeAPI.Infrastructure.Persistence;

namespace MuhasebeAPI.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _context;

        public InvoiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Invoice invoice)
        {
            await _context.Invoices.AddAsync(invoice);
        }

        public async Task<Invoice?> GetByIdAsync(int id)
        {
            return await _context.Invoices
                .Include(i => i.InvoiceItems)
                .ThenInclude(ii => ii.Stock)
                .Include(i => i.Company)
                .Include(i => i.Account)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await _context.Invoices
                .Include(i => i.InvoiceItems)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Invoice?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Invoices
                .Include(i => i.InvoiceItems)
                    .ThenInclude(ii => ii.Stock)
                .Include(i => i.Account)
                .Include(i => i.Company)
                .FirstOrDefaultAsync(i => i.Id == id);
        }
        public void Update(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
        }
        public void Delete(Invoice invoice)
        {
            _context.Invoices.Remove(invoice);
        }
    }
}
