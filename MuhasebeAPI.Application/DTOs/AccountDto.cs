using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Application.DTOs
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string AccountName { get; set; }
        public Guid AccountCategoryId { get; set; }
        public string AccountCategoryName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

    }
}
