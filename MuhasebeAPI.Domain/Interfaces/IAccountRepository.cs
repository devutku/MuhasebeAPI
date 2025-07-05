using MuhasebeAPI.Domain.Entities;
namespace MuhasebeAPI.Domain.Interfaces
{
    public interface IAccountRepository
    {
        public Task AddRangeAsync(IEnumerable<Account> accounts);
        public Task SaveChangesAsync();
    }
}
