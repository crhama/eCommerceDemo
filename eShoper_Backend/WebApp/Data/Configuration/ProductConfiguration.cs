using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Entities;

namespace WebApp.Data.Configuration
{
    public class ProductConfiguration
        : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.ProductCode)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.ProductDescription)
                .IsRequired()
                .HasMaxLength(300);

            //Navigation
            builder.HasOne(p => p.Brand)
                   .WithMany(b => b.Products)
                   .HasForeignKey(p => p.BrandId)
                   .IsRequired();
            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .IsRequired();
        }
    }
}
