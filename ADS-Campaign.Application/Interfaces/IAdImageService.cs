using ADS_Campaign.Application.DTOs.AdImage;

namespace ADS_Campaign.Application.Interfaces
{
    public interface IAdImageService
    {
        Task AddAsync(AddAdImageDto imageDto);
    }
}
