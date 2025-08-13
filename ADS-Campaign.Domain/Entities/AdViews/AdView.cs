using ADS_Campaign.Domain.Entities.Ads;

namespace ADS_Campaign.Domain.Entities.AdViews
{
    public class AdView : Entity<long>
    {
        public Guid AdId { get; set; }
        public string UserIp { get; set; }
        public DateTime ViewedAt { get; set; } = DateTime.UtcNow;
        public Ad Ad { get; set; }
    }
}
