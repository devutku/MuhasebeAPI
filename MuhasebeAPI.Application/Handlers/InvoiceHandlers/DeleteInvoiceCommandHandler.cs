using MediatR;
using MuhasebeAPI.Application.Commands.InvoiceCommands;
using MuhasebeAPI.Application.Interfaces;

namespace MuhasebeAPI.Application.Handlers.InvoiceHandlers
{
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, bool>
    {
        private readonly IInvoiceService _invoiceService;

        public DeleteInvoiceCommandHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public async Task<bool> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _invoiceService.DeleteInvoiceAsync(request.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
} 