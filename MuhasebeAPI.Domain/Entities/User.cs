using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<UserCompany> UserCompanies { get; set; } = new List<UserCompany>();
        public ICollection<Log> Logs { get; set; } = new List<Log>();
    }
}
