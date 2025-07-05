using MuhasebeAPI.Domain.Entities;
namespace MuhasebeAPI.Domain.Entities
{
    public class Log : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Action { get; set; } = null!;
        public string? Entity { get; set; }
        public Guid? EntityId { get; set; }
        public DateTime ActionDate { get; set; } = DateTime.UtcNow;

        public User User { get; set; } = null!;
    }
}