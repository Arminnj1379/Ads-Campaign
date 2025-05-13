using ADS_Campaign.Domain.Entities.Ads;
using Microsoft.EntityFrameworkCore;

namespace ADS_Campaign.Infrastructure.Persistance.Sql.Repositories
{
    public class AdRepository : BaseRepository<Ad>, IAdRepository
    {
        private readonly ApplicationDbContext _context;
        public AdRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Ad>> GetByUserIdAsync(string userid) => await _context.Ads.Where(a => a.UserId == userid).ToListAsync();
    }
}
