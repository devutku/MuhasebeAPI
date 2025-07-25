using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MuhasebeAPI.Application.Queries.DocumentQueries;
using MuhasebeAPI.Application.Interfaces;

namespace MuhasebeAPI.Application.Handlers.DocumentHandlers
{
    public class GetDocumentQueryHandler : IRequestHandler<GetDocumentQuery, Stream>
    {
        private readonly IDocumentService _documentService;

        public GetDocumentQueryHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<Stream> Handle(GetDocumentQuery request, CancellationToken cancellationToken)
        {
            return await _documentService.GetDocumentAsync(request.CompanyId, request.DocumentType);
        }
    }
} 