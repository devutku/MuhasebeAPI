namespace MuhasebeAPI.Domain.Entities
{
    public class CashTransaction : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public string TransactionType { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }
        public Guid? LinkedInvoiceId { get; set; }

        public Company Company { get; set; } = null!;
        public Invoice? LinkedInvoice { get; set; }
    }
}
