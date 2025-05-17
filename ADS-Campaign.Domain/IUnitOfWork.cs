using ADS_Campaign.Domain.Entities.AdImages;
using ADS_Campaign.Domain.Entities.Ads;
using ADS_Campaign.Domain.Entities.ApplicationUser;
using ADS_Campaign.Domain.Entities.Categories;

namespace ADS_Campaign.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IAdRepository AdRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IAdImageRepository AdImageRepository { get; }
        Task<int> Save();
    }
}
