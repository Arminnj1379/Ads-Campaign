using ADS_Campaign.Domain.Entities.Ads;

namespace ADS_Campaign.Domain.Entities.AdImages
{
    public class AdImage : Entity<long>
    {
        // Foreign Key: آگهی
        public Guid AdId { get; set; }
        public Ad Ad { get; set; }
        public string ImageUrl { get; set; }
        public int Order { get; set; } = 0;
    }
}
