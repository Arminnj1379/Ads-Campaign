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

        public async Task<List<Ad>> GetByUserIdAsync(string userid) => await _context.Ads.AsNoTracking().Where(a => a.UserId == userid).ToListAsync();

        public async Task<List<Ad>> GetAllAdsWithImages(string? title)
        {
            IQueryable<Ad> query = _context.Ads.AsNoTracking().AsSplitQuery()
            .Include(a => a.Images);

            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(a => a.Title.Contains(title));
            }
            return await query.ToListAsync();
        }

        public async Task<Ad> GetByIdWithImages(Guid id) => await _context.Ads.Include(a => a.Images).FirstOrDefaultAsync(a => a.Id == id);
    }
}
