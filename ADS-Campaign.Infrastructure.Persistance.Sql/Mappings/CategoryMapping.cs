using ADS_Campaign.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ADS_Campaign.Infrastructure.Persistance.Sql.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category", "ads").HasKey(u => u.Id);
            // Properties
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Description)
                .HasMaxLength(1000);

            // Auditing
            builder.Property(c => c.CreatedAt)
                .IsRequired();

            builder.HasOne(a => a.Parent).WithMany(k => k.Children).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
