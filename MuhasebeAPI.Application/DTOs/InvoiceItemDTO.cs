namespace MuhasebeAPI.Application.DTOs
{
    public class InvoiceItemDto
    {
        public int StockId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
