using MediatR;
using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Application.Queries.InvoiceQueries
{
    public class GetInvoiceByIdQuery : IRequest<Invoice?>
    {
        public Guid Id { get; set; }
    }
} 