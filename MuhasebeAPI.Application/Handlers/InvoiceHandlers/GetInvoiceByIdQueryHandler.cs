using MediatR;
using MuhasebeAPI.Application.Queries.InvoiceQueries;
using MuhasebeAPI.Application.Interfaces;

namespace MuhasebeAPI.Application.Handlers.InvoiceHandlers
{
    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, Domain.Entities.Invoice?>
    {
        private readonly IInvoiceService _invoiceService;

        public GetInvoiceByIdQueryHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public async Task<Domain.Entities.Invoice?> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            return await _invoiceService.GetByIdWithDetailsAsync(request.Id);
        }
    }
} 