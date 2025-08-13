using ADS_Campaign.Domain.Entities.AdViews;

namespace ADS_Campaign.Domain.Entities.Ads
{
    public interface IAdRepository : IRepository<Ad>
    {
        Task<List<Ad>> GetByUserIdAsync(string userid);
        Task<List<Ad>> GetAllAdsWithImages(string? title);
        Task<Ad> GetByIdWithImages(Guid id);
        Task<bool> CheckForAddView(Guid adId, string userIp, CancellationToken cancellationToken);
        Task AddAdViewAsync(AdView adView);
        Task<List<Ad>> GetRelatedAdsWithImagesAsync(Guid adId);
    }
}
