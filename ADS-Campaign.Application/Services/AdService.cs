using ADS_Campaign.Application.DTOs.Ad;
using ADS_Campaign.Application.DTOs.AdImage;
using ADS_Campaign.Application.Interfaces;
using ADS_Campaign.Application.Mapper;
using ADS_Campaign.Domain;
using ADS_Campaign.Domain.Entities.AdViews;

namespace ADS_Campaign.Application.Services
{
    public class AdService : IAdService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdImageService _imageService;
        public AdService(IUnitOfWork unitOfWork, IAdImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
        }

        public async Task AddAsync(AddAdDto adDto, string userid, string imageurl)
        {
            var id = Guid.NewGuid();
            await _unitOfWork.AdRepository.AddAsync(adDto.Factory(id, userid));
            await _unitOfWork.Save();
            await _imageService.AddAsync(new AddAdImageDto
            {
                AdId = id,
                ImageUrl = imageurl
            });
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
            ad.Address = updateAdDto.Address;
            ad.Price = updateAdDto.Price;
            ad.Title = updateAdDto.Title;
            ad.Description = updateAdDto.Description;
            ad.UpdatedAt = DateTime.Now;
            await _unitOfWork.Save();
        }

        public async Task<GetByIdAdDto> GetByIdAsync(Guid id)
        {
            var ad = await _unitOfWork.AdRepository.GetByIdWithImages(id);
            return ad.GetByIdAd();
        }

        public async Task IncrementViewCountAsync(Guid adId, string userIp, CancellationToken cancellationToken = default)
        {
            // چک کنیم که توی یک ساعت گذشته دوباره نیاد بشماره
            var alreadyViewed = await _unitOfWork.AdRepository.CheckForAddView(adId, userIp, cancellationToken);

            if (!alreadyViewed)
            {
                var ad = await _unitOfWork.AdRepository.GetByIdAsync(adId, cancellationToken);
                if (ad == null) return;

                ad.ViewCount += 1;
                var adview = new AdView
                {
                    AdId = adId,
                    UserIp = userIp,
                    ViewedAt = DateTime.UtcNow
                };
                await _unitOfWork.AdRepository.AddAdViewAsync(adview);
                await _unitOfWork.Save();
            }
        }
        public async Task<List<AllAdDto>> GetAllAsync(AdFilter? adFilter)
        {
            var ads = await _unitOfWork.AdRepository.GetAllAdsWithImages(adFilter?.Title);
            return ads.AllAd();
        }

        public async Task<List<AllAdDto>> GetByUserIdAsync(string userid)
        {
            var ads = await _unitOfWork.AdRepository.GetByUserIdAsync(userid);
            return ads.AllAd();
        }

        public async Task<List<AllAdDto>> GetRelatedAdsWithImagesAsync(Guid adId)
        {
            var relatedAds = await _unitOfWork.AdRepository.GetRelatedAdsWithImagesAsync(adId);
            return relatedAds.AllAd();
        }
    }
}
