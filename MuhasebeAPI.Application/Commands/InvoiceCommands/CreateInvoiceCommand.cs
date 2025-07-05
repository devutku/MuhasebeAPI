using MediatR;
using MuhasebeAPI.Application.DTOs;
using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Application.Commands.InvoiceCommands
{
    public class CreateInvoiceCommand : IRequest<Invoice>
    {
        public Guid CompanyId { get; set; }
        public Guid AccountId { get; set; }
        public string InvoiceType { get; set; } = null!;
        public DateTime InvoiceDate { get; set; }
        public List<InvoiceItemDto> Items { get; set; } = new List<InvoiceItemDto>();
        public Guid UserId { get; set; }
    }
} 