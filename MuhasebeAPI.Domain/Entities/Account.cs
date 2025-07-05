namespace MuhasebeAPI.Domain.Entities
{
    public class Account : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;

        public Company Company { get; set; } = null!;
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
