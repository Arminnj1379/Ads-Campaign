using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ADS_Campaign.Domain.Entities.Campaigns;

namespace ADS_Campaign.Infrastructure.Persistance.Sql.Mappings
{
    public class CampaignMapping : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.ToTable("Campaign", "ads").HasKey(u => u.Id);
            // Properties
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Budget)
                .HasColumnType("decimal(18,2)");

            // Relationships
            builder.HasOne(c => c.Ad)
                .WithOne(a => a.Campaign)
                .HasForeignKey<Campaign>(c => c.AdId)
                .OnDelete(DeleteBehavior.Restrict);

            // Auditing
            builder.Property(c => c.CreatedAt)
                .IsRequired();
        }
    }
}
