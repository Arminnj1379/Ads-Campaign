using ADS_Campaign.Domain.Entities.Ads;
using ADS_Campaign.Domain.Entities.Campaigns;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ADS_Campaign.Infrastructure.Persistance.Sql.Mappings
{
    public class AdMapping : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.ToTable("Ad", "ads").HasKey(u => u.Id);

            // Properties
            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(a => a.Description)
                .HasMaxLength(5000);

            builder.Property(a => a.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(a => a.Address)
                .HasMaxLength(300);

            // Relationships
            builder.HasOne(a => a.Category)
                .WithMany(c => c.Ads)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Campaign)
                .WithOne(c => c.Ad)
                .HasForeignKey<Campaign>(c => c.AdId)
                .OnDelete(DeleteBehavior.SetNull);

            // Auditing
            builder.Property(a => a.CreatedAt)
                .IsRequired();

            builder.Property(a => a.UpdatedAt)
                .IsRequired(false);
        }
    }
}
