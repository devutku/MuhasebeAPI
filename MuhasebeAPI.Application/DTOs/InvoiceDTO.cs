using MuhasebeAPI.Application.DTOs;
namespace MuhasebeAPI.Application.DTOs
{
    public class InvoiceDto
    {
        public Guid CompanyId { get; set; }
        public Guid AccountId { get; set; }
        public string InvoiceType { get; set; } = null!;
        public DateTime InvoiceDate { get; set; }
        public List<InvoiceItemDto> Items { get; set; } = new List<InvoiceItemDto>();
    }
}
