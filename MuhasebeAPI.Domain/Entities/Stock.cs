namespace MuhasebeAPI.Domain.Entities
{
    public class Stock
    {
        public Guid Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public string? Barcode { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Company Company { get; set; } = null!;
        public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }
}
