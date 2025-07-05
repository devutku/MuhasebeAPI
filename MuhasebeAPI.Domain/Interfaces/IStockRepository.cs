using MuhasebeAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuhasebeAPI.Domain.Interfaces
{
    public interface IStockRepository : IBaseRepository<Stock>
    {
        Task<IEnumerable<Stock>> GetStocksByCompanyIdAsync(Guid companyId);
    }
}
