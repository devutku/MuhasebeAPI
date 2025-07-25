using System;
using System.IO;
using System.Threading.Tasks;
using MuhasebeAPI.Application.Interfaces;

namespace MuhasebeAPI.Infrastructure.Services
{
    /// <summary>
    /// Handles document upload, storage, retrieval, and deletion. Emits events after upload.
    /// </summary>
    public class DocumentService : IDocumentService
    {
        private readonly string _documentRootPath;

        public DocumentService()
        {
            // You may want to inject this via configuration in a real app
            _documentRootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "documents");
        }

        public async Task UploadDocumentAsync(Guid companyId, DocumentType documentType, string fileName, Stream fileStream)
        {
            if (companyId == Guid.Empty)
                throw new ArgumentException("CompanyId is required.", nameof(companyId));
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("FileName is required.", nameof(fileName));
            if (fileStream == null || !fileStream.CanRead)
                throw new ArgumentException("FileStream is invalid.", nameof(fileStream));

            // Only allow PDF files
            if (!fileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("Only PDF files are allowed.");

            // Build directory and file path
            var companyDir = Path.Combine(_documentRootPath, companyId.ToString(), documentType.ToString());
            Directory.CreateDirectory(companyDir);
            var filePath = Path.Combine(companyDir, fileName);

            // Save the file
            using (var output = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await fileStream.CopyToAsync(output);
            }

            // TODO: Emit DocumentUploaded event via RabbitMQ
        }

        public async Task<Stream> GetDocumentAsync(Guid companyId, DocumentType documentType)
        {
            if (companyId == Guid.Empty)
                throw new ArgumentException("CompanyId is required.", nameof(companyId));

            var companyDir = Path.Combine(_documentRootPath, companyId.ToString(), documentType.ToString());
            if (!Directory.Exists(companyDir))
                return null;

            // Get the first PDF file in the directory (assuming one per type)
            var pdfFiles = Directory.GetFiles(companyDir, "*.pdf");
            if (pdfFiles.Length == 0)
                return null;

            // Open the file for reading
            var filePath = pdfFiles[0];
            var memoryStream = new MemoryStream();
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await fileStream.CopyToAsync(memoryStream);
            }
            memoryStream.Position = 0;
            return memoryStream;
        }

        public async Task DeleteDocumentAsync(Guid companyId, DocumentType documentType)
        {
            if (companyId == Guid.Empty)
                throw new ArgumentException("CompanyId is required.", nameof(companyId));

            var companyDir = Path.Combine(_documentRootPath, companyId.ToString(), documentType.ToString());
            if (!Directory.Exists(companyDir))
                return;

            var pdfFiles = Directory.GetFiles(companyDir, "*.pdf");
            foreach (var file in pdfFiles)
            {
                File.Delete(file);
            }
            // Optionally, delete the directory if empty
            if (Directory.GetFiles(companyDir).Length == 0 && Directory.GetDirectories(companyDir).Length == 0)
            {
                Directory.Delete(companyDir);
            }
        }
    }
} 