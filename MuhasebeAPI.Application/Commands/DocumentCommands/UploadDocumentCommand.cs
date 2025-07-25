using MediatR;
using System;
using System.IO;
using MuhasebeAPI.Application.Interfaces;

namespace MuhasebeAPI.Application.Commands.DocumentCommands
{
    public class UploadDocumentCommand : IRequest<Unit>
    {
        public Guid CompanyId { get; set; }
        public DocumentType DocumentType { get; set; }
        public string FileName { get; set; }
        public Stream FileStream { get; set; }

        public UploadDocumentCommand(Guid companyId, DocumentType documentType, string fileName, Stream fileStream)
        {
            CompanyId = companyId;
            DocumentType = documentType;
            FileName = fileName;
            FileStream = fileStream;
        }
    }
} 