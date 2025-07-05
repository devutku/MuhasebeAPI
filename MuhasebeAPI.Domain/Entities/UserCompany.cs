namespace MuhasebeAPI.Domain.Entities
{
    public class UserCompany
    {
            public Guid UserId { get; set; }
            public User User { get; set; } = null!;
            public int CompanyId { get; set; }
            public Company Company { get; set; } = null!;
        }
    }
