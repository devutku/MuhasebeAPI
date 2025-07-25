using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MuhasebeAPI.Application.Commands.DocumentCommands;
using MuhasebeAPI.Application.Interfaces;

namespace MuhasebeAPI.Application.Handlers.DocumentHandlers
{
    public class UploadDocumentCommandHandler : IRequestHandler<UploadDocumentCommand, Unit>
    {
        private readonly IDocumentService _documentService;

        public UploadDocumentCommandHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<Unit> Handle(UploadDocumentCommand request, CancellationToken cancellationToken)
        {
            await _documentService.UploadDocumentAsync(request.CompanyId, request.DocumentType, request.FileName, request.FileStream);
            return Unit.Value;
        }
    }
} 