using ADS_Campaign.Application.DTOs.Ad;
using ADS_Campaign.Domain.Entities.Ads;
using ADS_Campaign.Domain.Enums;

namespace ADS_Campaign.Application.Mapper
{
    public static class AdMapper
    {
        public static string GetStatusName(this AdStatus adStatus)
        {
            if (adStatus == AdStatus.New)
            {
                return "نو";
            }
            if (adStatus == AdStatus.AlmostNew)
            {
                return "در حد نو";
            }
            if (adStatus == AdStatus.Used)
            {
                return "کارکرده";
            }
            return "";
        }
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
                Location = addAdDto.Location,
                Number = addAdDto.Number,
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
                Status = ad.Status.GetStatusName(),
                Title = ad.Title,
                UpdatedAt = ad.UpdatedAt,
                UserId = ad.UserId,
                Location = ad.Location,
                Images = ad.Images.Select(i => i.ImageUrl).ToList(),
                Number = ad.Number,
                ViewCount = ad.ViewCount,
                CreationDateDesc = ad.CreatedAt.GetRelativeTime()
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
                Status = a.Status.GetStatusName(),
                Title = a.Title,
                UpdatedAt = a.UpdatedAt,
                UserId = a.UserId,
                Images = a.Images.Select(i => i.ImageUrl).ToList(),
                Location = a.Location,
                Number = a.Number,
                CreationDateDesc = a.CreatedAt.GetRelativeTime(),
                ViewCount = a.ViewCount
            }).ToList();
        }

        public static string GetRelativeTime(this DateTime dateTime)
        {
            var now = DateTime.Now;
            var ts = now - dateTime;

            if (ts.TotalMinutes < 1)
                return "لحظاتی پیش";
            if (ts.TotalMinutes < 60)
                return $"{(int)ts.TotalMinutes} دقیقه پیش";
            if (ts.TotalHours < 24)
                return $"{(int)ts.TotalHours} ساعت پیش";
            if (ts.TotalDays < 7)
                return $"{(int)ts.TotalDays} روز پیش";
            if (ts.TotalDays < 30)
                return $"{(int)(ts.TotalDays / 7)} هفته پیش";
            if (ts.TotalDays < 365)
                return $"{(int)(ts.TotalDays / 30)} ماه پیش";

            return $"{(int)(ts.TotalDays / 365)} سال پیش";
        }


    }
}
