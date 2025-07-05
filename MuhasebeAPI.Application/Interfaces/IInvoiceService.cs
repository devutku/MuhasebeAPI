using MuhasebeAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using MuhasebeAPI.Application.DTOs;

public interface IInvoiceService
{
    Task<Invoice> CreateInvoiceAsync(InvoiceDto dto, Guid userId);
    Task<Invoice?> GetByIdWithDetailsAsync(Guid id);
    Task<IEnumerable<Invoice>> GetAllAsync();
    //Task UpdateInvoiceAsync(Guid id, InvoiceDto dto);
    Task DeleteInvoiceAsync(Guid id);
}
