using MuhasebeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuhasebeAPI.Application.Interfaces
{
    public interface ICustomerService
    {
        Task AddAsync(Customer customer);
        Task<Customer?> GetByIdAsync(Guid id);
        Task<List<Customer>> GetAllAsync();
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid id);
    }
} 