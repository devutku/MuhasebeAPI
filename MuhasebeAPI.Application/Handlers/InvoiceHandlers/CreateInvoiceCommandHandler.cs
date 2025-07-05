using MediatR;
using MuhasebeAPI.Application.Commands.InvoiceCommands;
using MuhasebeAPI.Application.Interfaces;
using MuhasebeAPI.Application.DTOs;

namespace MuhasebeAPI.Application.Handlers.InvoiceHandlers
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Domain.Entities.Invoice>
    {
        private readonly IInvoiceService _invoiceService;

        public CreateInvoiceCommandHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public async Task<Domain.Entities.Invoice> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var dto = new InvoiceDto
            {
                CompanyId = request.CompanyId,
                AccountId = request.AccountId,
                InvoiceType = request.InvoiceType,
                InvoiceDate = request.InvoiceDate,
                Items = request.Items
            };

            return await _invoiceService.CreateInvoiceAsync(dto, request.UserId);
        }
    }
} 