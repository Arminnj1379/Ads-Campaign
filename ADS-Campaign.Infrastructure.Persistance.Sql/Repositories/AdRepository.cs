using ADS_Campaign.Domain.Entities.Ads;
using ADS_Campaign.Domain.Entities.AdViews;
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

        public async Task<List<Ad>> GetAllAdsWithImages(string? title, int? categoryId)
        {
            IQueryable<Ad> query = _context.Ads.AsNoTracking().AsSplitQuery()
            .Include(a => a.Images);
            var category = await _context.Categories.FindAsync(categoryId);
            if (category?.Name.Trim() == "همه")
            {
                return await query.ToListAsync();
            }
            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(a => a.Title.Contains(title));
            }
            if (categoryId != null)
            {
                query = query.Where(a => a.CategoryId == categoryId);
            }
            return await query.ToListAsync();
        }

        public async Task<List<Ad>> GetRelatedAdsWithImagesAsync(Guid adId)
        {
            var ad = await _context.Ads.FindAsync(adId);
            var relatedAds = await _context.Ads.AsNoTracking().Include(a => a.Images).Where(a => a.Category == ad.Category).Take(3).ToListAsync();
            if (relatedAds.Count == 0)
            {
                relatedAds = await _context.Ads.AsNoTracking().Include(a => a.Images).Take(3).ToListAsync();
            }
            return relatedAds;
        }

        public async Task<bool> CheckForAddView(Guid adId, string userIp, CancellationToken cancellationToken)
            => await _context.AdViews.AnyAsync(v => v.AdId == adId && v.UserIp == userIp &&
                               v.ViewedAt > DateTime.UtcNow.AddHours(-1),
                               cancellationToken);

        public async Task<Ad> GetByIdWithImages(Guid id) => await _context.Ads.Include(a => a.Images).FirstOrDefaultAsync(a => a.Id == id);

        public async Task AddAdViewAsync(AdView adView) => await _context.AdViews.AddAsync(adView);
    }
}
