namespace MuhasebeAPI.Domain.Entities
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public int CompanyId { get; set; }
        public int AccountId { get; set; }
        public string InvoiceType { get; set; } = null!; // Giris / Cikis
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Company Company { get; set; } = null!;
        public Account Account { get; set; } = null!;
        public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
        public ICollection<CashTransaction>? CashTransactions { get; set; }
    }
}
