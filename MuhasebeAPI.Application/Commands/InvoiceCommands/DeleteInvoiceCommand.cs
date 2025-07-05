using MediatR;

namespace MuhasebeAPI.Application.Commands.InvoiceCommands
{
    public class DeleteInvoiceCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
} 