using ADS_Campaign.Domain.Entities.AdImages;
using ADS_Campaign.Domain.Entities.Campaigns;
using ADS_Campaign.Domain.Entities.Categories;
using ADS_Campaign.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace ADS_Campaign.Domain.Entities.Ads
{
    public class Ad : Entity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }

        // Foreign Key: دسته‌بندی
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Foreign Key: کاربر ثبت‌کننده آگهی
        public string UserId { get; set; }  // IdentityUser.Id => string
        public IdentityUser User { get; set; }

        // وضعیت آگهی
        public AdStatus Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // رابطه با تصاویر
        public ICollection<AdImage> Images { get; set; }

        // رابطه با کمپین
        public Campaign Campaign { get; set; }
    }
}
