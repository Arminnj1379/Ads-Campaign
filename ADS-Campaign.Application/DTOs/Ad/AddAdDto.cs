using ADS_Campaign.Domain.Enums;

namespace ADS_Campaign.Application.DTOs.Ad
{
    public class AddAdDto 
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string? UserId { get; set; }
        public int CategoryId { get; set; }
        public AdStatus Status { get; set; }
    }
}
