namespace MuhasebeAPI.Domain.Entities
{
    public class UserCompany : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;
    }
}
