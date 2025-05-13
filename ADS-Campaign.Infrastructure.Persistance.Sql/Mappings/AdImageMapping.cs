using ADS_Campaign.Domain.Entities.AdImages;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ADS_Campaign.Infrastructure.Persistance.Sql.Mappings
{
    public class AdImageMapping : IEntityTypeConfiguration<AdImage>
    {
        public void Configure(EntityTypeBuilder<AdImage> builder)
        {
            builder.ToTable("AdImage", "ads").HasKey(u => u.Id);

            // Properties
            builder.Property(i => i.ImageUrl)
                .IsRequired()
                .HasMaxLength(1000);

            // Order (optional)
            builder.Property(i => i.Order)
                .IsRequired()
                .HasDefaultValue(0);

            // Relationships
            builder.HasOne(i => i.Ad)
                .WithMany(a => a.Images)
                .HasForeignKey(i => i.AdId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
