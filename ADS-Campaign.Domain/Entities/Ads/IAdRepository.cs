namespace ADS_Campaign.Domain.Entities.Ads
{
    public interface IAdRepository : IRepository<Ad>
    {
        Task<List<Ad>> GetByUserIdAsync(string userid);
        Task<List<Ad>> GetAllAdsWithImages(string? title);
        Task<Ad> GetByIdWithImages(Guid id);
    }
}
