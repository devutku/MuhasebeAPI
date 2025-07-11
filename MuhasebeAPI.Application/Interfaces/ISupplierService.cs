using MuhasebeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuhasebeAPI.Application.Interfaces
{
    public interface ISupplierService
    {
        Task AddAsync(Supplier supplier);
        Task<Supplier?> GetByIdAsync(Guid id);
        Task<List<Supplier>> GetAllAsync();
        Task UpdateAsync(Supplier supplier);
        Task DeleteAsync(Guid id);
    }
} 