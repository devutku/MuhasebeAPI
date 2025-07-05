using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Domain.Interfaces
{
    public interface IInvoiceRepository : IBaseRepository<Invoice>
    {
        Task<Invoice?> GetByIdWithDetailsAsync(Guid id);
        Task<IEnumerable<Invoice>> GetAllWithDetailsAsync();
    }
}
