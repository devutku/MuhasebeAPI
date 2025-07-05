namespace MuhasebeAPI.Domain.Entities
{
    public class CashTransaction
    {
        public Guid Id { get; set; }
        public int CompanyId { get; set; }
        public string TransactionType { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }
        public int? LinkedInvoiceId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Company Company { get; set; } = null!;
        public Invoice? LinkedInvoice { get; set; }
    }
}
