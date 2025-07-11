using System.Collections.Generic;

namespace MuhasebeAPI.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? TaxNumber { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
} 