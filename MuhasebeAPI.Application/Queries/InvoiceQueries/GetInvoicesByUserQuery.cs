using MediatR;
using MuhasebeAPI.Application.DTOs;

namespace MuhasebeAPI.Application.Queries.InvoiceQueries
{
    public class GetInvoicesByUserQuery : IRequest<List<InvoiceDto>>
    {
        public Guid UserId { get; set; }
    }
} 