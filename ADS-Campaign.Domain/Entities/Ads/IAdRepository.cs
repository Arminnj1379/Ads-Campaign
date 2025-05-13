namespace ADS_Campaign.Domain.Entities.Ads
{
    public interface IAdRepository : IRepository<Ad>
    {
        Task<List<Ad>> GetByUserIdAsync(string userid);
    }
}
