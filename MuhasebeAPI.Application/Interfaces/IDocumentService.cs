using System;
using System.IO;
using System.Threading.Tasks;

namespace MuhasebeAPI.Application.Interfaces
{
    public enum DocumentType
    {
        Invoice,
        Receipt,
        Contract,
        Report
    }

    public interface IDocumentService
    {
        Task UploadDocumentAsync(Guid companyId, DocumentType documentType, string fileName, Stream fileStream);
        Task<Stream> GetDocumentAsync(Guid companyId, DocumentType documentType);
        Task DeleteDocumentAsync(Guid companyId, DocumentType documentType);
    }
}