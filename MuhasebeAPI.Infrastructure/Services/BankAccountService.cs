using MuhasebeAPI.Application.Interfaces;
using MuhasebeAPI.Domain.Entities;
using MuhasebeAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MuhasebeAPI.Infrastructure.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly AppDbContext _context;
        public BankAccountService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(BankAccount bankAccount)
        {
            await _context.BankAccounts.AddAsync(bankAccount);
            await _context.SaveChangesAsync();
        }
        public async Task<BankAccount?> GetByIdAsync(Guid id)
        {
            return await _context.BankAccounts.FindAsync(id);
        }
        public async Task<List<BankAccount>> GetAllAsync()
        {
            return await _context.BankAccounts.ToListAsync();
        }
        public async Task UpdateAsync(BankAccount bankAccount)
        {
            _context.BankAccounts.Update(bankAccount);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var bankAccount = await _context.BankAccounts.FindAsync(id);
            if (bankAccount != null)
            {
                _context.BankAccounts.Remove(bankAccount);
                await _context.SaveChangesAsync();
            }
        }
    }
} 