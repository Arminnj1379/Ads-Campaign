using ADS_Campaign.Application.DTOs.Ad;

namespace ADS_Campaign.Application.Interfaces
{
    public interface IAdService
    {
        Task AddAsync(AddAdDto adDto, string userid, string imageurl);
        Task<List<AllAdDto>> GetAllAsync();
        Task UpdateAsync(Guid id, UpdateAdDto updateAdDto);
        Task<GetByIdAdDto> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task<List<AllAdDto>> GetByUserIdAsync(string userid);
    }
}
