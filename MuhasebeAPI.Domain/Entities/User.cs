using MuhasebeAPI.Domain.Entities;

namespace MuhasebeAPI.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Email
        {
            get; set;
        }
        public string PasswordHash { get; set; } = null!;
        public string AreaCode { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public UserRole Role
        {
            get; set;
        }

        public ICollection<UserCompany> UserCompanies { get; set; } = new List<UserCompany>();
        public ICollection<Log> Logs { get; set; } = new List<Log>();
    }
}
