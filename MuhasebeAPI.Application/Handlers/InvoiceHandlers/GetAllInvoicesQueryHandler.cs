using MediatR;
using MuhasebeAPI.Application.Queries.InvoiceQueries;
using MuhasebeAPI.Application.Interfaces;

namespace MuhasebeAPI.Application.Handlers.InvoiceHandlers
{
    public class GetAllInvoicesQueryHandler : IRequestHandler<GetAllInvoicesQuery, IEnumerable<Domain.Entities.Invoice>>
    {
        private readonly IInvoiceService _invoiceService;

        public GetAllInvoicesQueryHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public async Task<IEnumerable<Domain.Entities.Invoice>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
        {
            return await _invoiceService.GetAllAsync();
        }
    }
} 