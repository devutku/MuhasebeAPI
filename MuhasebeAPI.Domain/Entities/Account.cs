namespace MuhasebeAPI.Domain.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Company Company { get; set; } = null!;
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
