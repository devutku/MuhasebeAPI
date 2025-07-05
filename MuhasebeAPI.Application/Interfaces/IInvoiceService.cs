using MuhasebeAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using MuhasebeAPI.Application.DTOs;

public interface IInvoiceService
{
    Task<Invoice> CreateInvoiceAsync(InvoiceDto dto, int userId);
    Task<Invoice?> GetByIdWithDetailsAsync(int id);
    Task<IEnumerable<Invoice>> GetAllAsync();
    //Task UpdateInvoiceAsync(int id, InvoiceDto dto);
    Task DeleteInvoiceAsync(int id);
}
