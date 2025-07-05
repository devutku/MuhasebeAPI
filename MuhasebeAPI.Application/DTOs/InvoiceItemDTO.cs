namespace MuhasebeAPI.Application.DTOs
{
    public class InvoiceItemDto
    {
        public Guid StockId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
