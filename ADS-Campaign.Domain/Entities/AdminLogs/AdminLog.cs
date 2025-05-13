
using Microsoft.AspNetCore.Identity;

namespace ADS_Campaign.Domain.Entities.AdminLogs
{
    public class AdminLog : Entity<long>
    {
        // Foreign Key: ادمین (کاربر Identity)
        public string AdminId { get; set; }
        public IdentityUser Admin { get; set; }
        public string Action { get; set; } 
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
