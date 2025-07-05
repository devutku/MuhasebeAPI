namespace MuhasebeAPI.Domain.Entities
{
    public class InvoiceItem : BaseEntity
    {
        public Guid InvoiceId { get; set; }
        public Guid StockId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public Invoice Invoice { get; set; } = null!;
        public Stock Stock { get; set; } = null!;
    }
}
