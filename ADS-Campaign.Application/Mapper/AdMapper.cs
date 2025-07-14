using ADS_Campaign.Application.DTOs.Ad;
using ADS_Campaign.Domain.Entities.Ads;

namespace ADS_Campaign.Application.Mapper
{
    public static class AdMapper
    {
        public static Ad Factory(this AddAdDto addAdDto, Guid id, string userid)
        {
            return new Ad
            {
                CategoryId = addAdDto.CategoryId,
                CreatedAt = DateTime.Now,
                Id = id,
                Description = addAdDto.Description,
                Address = addAdDto.Address,
                Price = addAdDto.Price,
                Status = addAdDto.Status,
                Title = addAdDto.Title,
                UpdatedAt = null,
                UserId = userid,
            };
        }

        public static GetByIdAdDto GetByIdAd(this Ad ad)
        {
            return new GetByIdAdDto
            {
                CategoryId = ad.CategoryId,
                CreatedAt = ad.CreatedAt,
                Description = ad.Description,
                Id = ad.Id,
                Address = ad.Address,
                Price = ad.Price,
                Status = ad.Status,
                Title = ad.Title,
                UpdatedAt = ad.UpdatedAt,
                UserId = ad.UserId
            };
        }

        public static List<AllAdDto> AllAd(this List<Ad> ads)
        {
            return ads.Select(a => new AllAdDto
            {
                CategoryId = a.CategoryId,
                CreatedAt = a.CreatedAt,
                Description = a.Description,
                Id = a.Id,
                Address = a.Address,
                Price = a.Price,
                Status = a.Status,
                Title = a.Title,
                UpdatedAt = a.UpdatedAt,
                UserId = a.UserId
            }).ToList();
        }

    }
}
