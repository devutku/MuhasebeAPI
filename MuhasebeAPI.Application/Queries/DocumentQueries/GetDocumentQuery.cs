using MediatR;
using System;
using System.IO;
using MuhasebeAPI.Application.Interfaces;

namespace MuhasebeAPI.Application.Queries.DocumentQueries
{
    public class GetDocumentQuery : IRequest<Stream>
    {
        public Guid CompanyId { get; set; }
        public DocumentType DocumentType { get; set; }

        public GetDocumentQuery(Guid companyId, DocumentType documentType)
        {
            CompanyId = companyId;
            DocumentType = documentType;
        }
    }
} 