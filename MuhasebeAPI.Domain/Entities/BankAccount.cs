using System.Collections.Generic;

namespace MuhasebeAPI.Domain.Entities
{
    public class BankAccount : BaseEntity
    {
        public string BankName { get; set; } = null!;
        public string? IBAN { get; set; }
        public string? AccountNumber { get; set; }
        public string? Branch { get; set; }
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
} 