using MediatR;
using System;
using MuhasebeAPI.Application.Interfaces;

namespace MuhasebeAPI.Application.Commands.DocumentCommands
{
    public class DeleteDocumentCommand : IRequest<Unit>
    {
        public Guid CompanyId { get; set; }
        public DocumentType DocumentType { get; set; }

        public DeleteDocumentCommand(Guid companyId, DocumentType documentType)
        {
            CompanyId = companyId;
            DocumentType = documentType;
        }
    }
} 