using ADS_Campaign.Application.DTOs.Ad;
using ADS_Campaign.Application.Interfaces;
using ADS_Campaign.Application.Mapper;
using ADS_Campaign.Domain;

namespace ADS_Campaign.Application.Services
{
    public class AdService : IAdService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(AddAdDto adDto, string userid)
        {
            var id = Guid.NewGuid();
            await _unitOfWork.AdRepository.AddAsync(adDto.Factory(id, userid));
            await _unitOfWork.Save();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.AdRepository.DeleteAsync(id);
            await _unitOfWork.Save();
        }

        public async Task UpdateAsync(Guid id, UpdateAdDto updateAdDto)
        {
            var ad = await _unitOfWork.AdRepository.GetByIdAsync(id);
            ad.CategoryId = updateAdDto.CategoryId;
            ad.Status = updateAdDto.Status;
            ad.Location = updateAdDto.Location;
            ad.Price = updateAdDto.Price;
            ad.Title = updateAdDto.Title;
            ad.Description = updateAdDto.Description;
            ad.UpdatedAt = DateTime.Now;
            await _unitOfWork.Save();
        }

        public async Task<GetByIdAdDto> GetByIdAsync(Guid id)
        {
            var ad = await _unitOfWork.AdRepository.GetByIdAsync(id);
            return ad.GetByIdAd();
        }

        public async Task<List<AllAdDto>> GetAllAsync()
        {
            var ads = await _unitOfWork.AdRepository.GetAllAsync();
            return ads.AllAd();
        }

        public async Task<List<AllAdDto>> GetByUserIdAsync(string userid)
        {
            var ads = await _unitOfWork.AdRepository.GetByUserIdAsync(userid);
            return ads.AllAd();
        }
    }
}
