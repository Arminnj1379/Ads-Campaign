using ADS_Campaign.Domain.Entities.Ads;

namespace ADS_Campaign.Domain.Entities.Campaigns
{
    public class Campaign : Entity<Guid>
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Foreign Key: آگهی مرتبط
        public Guid AdId { get; set; }
        public Ad Ad { get; set; }

        public int ClickCount { get; set; } = 0;
        public int ViewCount { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
