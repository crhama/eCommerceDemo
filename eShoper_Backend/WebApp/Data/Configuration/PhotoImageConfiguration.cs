using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebApp.Entities;

namespace WebApp.Data.Configuration
{
    public class PhotoImageConfiguration
        : IEntityTypeConfiguration<PhotoImage>
    {
        public void Configure(EntityTypeBuilder<PhotoImage> builder)
        {
            builder.Property(img => img.OriginalName)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(img => img.OriginalName)
                .HasMaxLength(300);

            //Navigation
            builder.HasOne(img => img.Product)
                   .WithMany(p => p.PhotoImages)
                   .HasForeignKey(p => p.ProductId)
                   .IsRequired();
        }
    }
}
