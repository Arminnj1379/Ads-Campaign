using ADS_Campaign.Domain;
using ADS_Campaign.Domain.Entities.Ads;
using ADS_Campaign.Domain.Entities.ApplicationUser;

namespace ADS_Campaign.Infrastructure.Persistance.Sql
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserRepository UserRepository { get; }
        public IAdRepository AdRepository { get; }

        public UnitOfWork(ApplicationDbContext context, IUserRepository userRepository, IAdRepository adRepository)
        {
            _context = context;
            UserRepository = userRepository;
            AdRepository = adRepository;
        }
        public async Task<int> Save() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();

    }
}
