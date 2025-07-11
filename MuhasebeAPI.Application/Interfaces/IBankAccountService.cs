using MuhasebeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuhasebeAPI.Application.Interfaces
{
    public interface IBankAccountService
    {
        Task AddAsync(BankAccount bankAccount);
        Task<BankAccount?> GetByIdAsync(Guid id);
        Task<List<BankAccount>> GetAllAsync();
        Task UpdateAsync(BankAccount bankAccount);
        Task DeleteAsync(Guid id);
    }
} 