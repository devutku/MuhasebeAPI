using MuhasebeAPI.Application.DTOs;

public class InvoiceUpdateDto
{
    public DateTime InvoiceDate { get; set; }
    public List<InvoiceItemDto> Items { get; set; } = new();
}