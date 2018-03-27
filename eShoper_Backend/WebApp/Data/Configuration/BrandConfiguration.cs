using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Entities;

namespace WebApp.Data.Configuration
{
    public class BrandConfiguration
        : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(b => b.BrandName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
