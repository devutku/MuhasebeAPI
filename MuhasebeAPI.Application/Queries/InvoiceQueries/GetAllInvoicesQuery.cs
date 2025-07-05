using MediatR;
using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Application.Queries.InvoiceQueries
{
    public class GetAllInvoicesQuery : IRequest<IEnumerable<Invoice>>
    {
    }
} 