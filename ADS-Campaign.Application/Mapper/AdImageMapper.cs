using ADS_Campaign.Application.DTOs.AdImage;
using ADS_Campaign.Domain.Entities.AdImages;

namespace ADS_Campaign.Application.Mapper
{
    public static class AdImageMapper
    {
        public static AdImage Factory(this AddAdImageDto imageDto)
        {
            return new AdImage
            {
                AdId = imageDto.AdId,
                ImageUrl = imageDto.ImageUrl,
                Order = 0
            };
        }
    }
}
