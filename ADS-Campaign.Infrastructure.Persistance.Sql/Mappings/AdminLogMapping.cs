using ADS_Campaign.Domain.Entities.AdminLogs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ADS_Campaign.Infrastructure.Persistance.Sql.Mappings
{
    public class AdminLogMapping : IEntityTypeConfiguration<AdminLog>
    {
        public void Configure(EntityTypeBuilder<AdminLog> builder)
        {
            builder.ToTable("AdminLog", "ads").HasKey(u => u.Id);

            // Properties
            builder.Property(l => l.Action)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(l => l.Description)
                .HasMaxLength(1000);

            // Relationships
            builder.HasOne(l => l.Admin)
                .WithMany()
                .HasForeignKey(l => l.AdminId)
                .OnDelete(DeleteBehavior.Cascade);

            // Auditing
            builder.Property(l => l.CreatedAt)
                .IsRequired();
        }
    }
}
