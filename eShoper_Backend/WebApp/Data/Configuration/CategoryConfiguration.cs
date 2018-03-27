using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Entities;

namespace WebApp.Data.Configuration
{
    public class CategoryConfiguration
        : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(100);

            //Navigation
            builder.HasOne(c => c.ParentCategory)
                   .WithMany(c => c.ChildrenCategory)
                   .HasForeignKey(c => c.ParentCategoryId);                   
        }
    }
}
