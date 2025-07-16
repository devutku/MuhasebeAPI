namespace MuhasebeAPI.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? TaxNumber { get; set; } // Vergi Numarası
        public string? TaxOffice { get; set; } // Vergi Dairesi
        public string? Address { get; set; }   // Adres
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<UserCompany> UserCompanies { get; set; } = new List<UserCompany>();
        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
        public ICollection<CashTransaction> CashTransactions { get; set; } = new List<CashTransaction>();

    }
}
