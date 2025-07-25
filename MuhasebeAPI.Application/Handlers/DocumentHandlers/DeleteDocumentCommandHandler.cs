using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MuhasebeAPI.Application.Commands.DocumentCommands;
using MuhasebeAPI.Application.Interfaces;

namespace MuhasebeAPI.Application.Handlers.DocumentHandlers
{
    public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand, Unit>
    {
        private readonly IDocumentService _documentService;

        public DeleteDocumentCommandHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<Unit> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
        {
            await _documentService.DeleteDocumentAsync(request.CompanyId, request.DocumentType);
            return Unit.Value;
        }
    }
} 