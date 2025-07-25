using System;

namespace MuhasebeAPI.Domain.Entities
{
    public class Document : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public string DocumentType { get; set; } // Store as string for flexibility
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public Guid UploadedBy { get; set; }
        public DateTime UploadedAt { get; set; }
        public string Status { get; set; } // e.g., Pending, Approved, Rejected

        // Navigation property (optional)
        public Company Company { get; set; }
    }
} 