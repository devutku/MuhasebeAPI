namespace MuhasebeAPI.Domain.Entities
{
    public class Stock : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public string? Barcode { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public Company Company { get; set; } = null!;
        public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }
}
