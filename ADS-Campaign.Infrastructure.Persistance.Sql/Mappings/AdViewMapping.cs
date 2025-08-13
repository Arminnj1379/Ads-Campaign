using ADS_Campaign.Domain.Entities.AdViews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ADS_Campaign.Infrastructure.Persistance.Sql.Mappings
{
    public class AdViewMapping : IEntityTypeConfiguration<AdView>
    {
        public void Configure(EntityTypeBuilder<AdView> builder)
        {
            builder.ToTable("AdViews", "ads");

            builder.HasKey(v => v.Id);
            builder.Property(v => v.UserIp).HasMaxLength(50).IsRequired();
            builder.Property(v => v.ViewedAt)
                   .HasDefaultValueSql("GETUTCDATE()");
        }

    }
}
