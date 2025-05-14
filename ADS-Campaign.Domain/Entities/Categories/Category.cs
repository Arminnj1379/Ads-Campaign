using ADS_Campaign.Domain.Entities.Ads;

namespace ADS_Campaign.Domain.Entities.Categories
{
    public class Category : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Category Parent { get; set; }
        public ICollection<Category> Children { get; set; }
        public ICollection<Ad> Ads { get; set; }
    }
}
