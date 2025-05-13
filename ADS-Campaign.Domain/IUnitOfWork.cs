using ADS_Campaign.Domain.Entities.Ads;
using ADS_Campaign.Domain.Entities.ApplicationUser;

namespace ADS_Campaign.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IAdRepository AdRepository { get; }
        Task<int> Save();
    }
}
