using MuhasebeAPI.Application.DTOs;
namespace MuhasebeAPI.Application.DTOs
{
    public class InvoiceDto
    {
        public int CompanyId { get; set; }
        public int AccountId { get; set; }
        public string InvoiceType { get; set; } = null!;
        public DateTime InvoiceDate { get; set; }
        public List<InvoiceItemDto> Items { get; set; } = new List<InvoiceItemDto>();
    }
}
