using ADS_Campaign.Domain.Entities.AdImages;
using Microsoft.EntityFrameworkCore;

namespace ADS_Campaign.Infrastructure.Persistance.Sql.Repositories
{
    public class AdImageRepository : BaseRepository<AdImage>, IAdImageRepository
    {
        private readonly ApplicationDbContext _context;
        public AdImageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
