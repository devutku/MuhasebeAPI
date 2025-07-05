namespace MuhasebeAPI.Domain.Entities
{
    public class InvoiceItem

    {
        public Guid Id { get; set; }
        public int InvoiceId { get; set; }
        public int StockId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Invoice Invoice { get; set; } = null!;
        public Stock Stock { get; set; } = null!;
    }
}
