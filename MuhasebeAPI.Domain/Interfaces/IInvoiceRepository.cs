using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Domain.Interfaces
{
    public interface IInvoiceRepository
    {
        Task AddAsync(Invoice invoice);
        Task SaveChangesAsync();
        Task<Invoice?> GetByIdAsync(int id);
        Task<Invoice?> GetByIdWithDetailsAsync(int id);
        Task<IEnumerable<Invoice>> GetAllAsync();
        void Update(Invoice invoice);
        void Delete(Invoice invoice);
    }

}
