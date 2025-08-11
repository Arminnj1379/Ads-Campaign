using ADS_Campaign.Domain.Enums;

namespace ADS_Campaign.Application.DTOs.Ad
{
    public class GetByIdAdDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; } 
        public AdStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public List<string> Images { get; set; }

    }
}
