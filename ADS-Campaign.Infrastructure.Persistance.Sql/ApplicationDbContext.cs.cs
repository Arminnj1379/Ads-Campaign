using ADS_Campaign.Domain.Entities.AdImages;
using ADS_Campaign.Domain.Entities.AdminLogs;
using ADS_Campaign.Domain.Entities.Ads;
using ADS_Campaign.Domain.Entities.ApplicationRole;
using ADS_Campaign.Domain.Entities.ApplicationUser;
using ADS_Campaign.Domain.Entities.Campaigns;
using ADS_Campaign.Domain.Entities.Categories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ADS_Campaign.Infrastructure.Persistance.Sql
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<AdImage> AdImages { get; set; }
        public DbSet<AdminLog> AdminLogs { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
