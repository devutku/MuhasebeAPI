namespace MuhasebeAPI.Domain.Entities
{
    public class AccountCategory : BaseEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }

    public class Account : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public Guid AccountCategoryId { get; set; }
        public AccountCategory AccountCategory { get; set; } = null!;
        public Company Company { get; set; } = null!;
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public Guid? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public Guid? BankAccountId { get; set; }
        public BankAccount? BankAccount { get; set; }
    }
}
