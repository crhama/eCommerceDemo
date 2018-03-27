using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Data.Configuration;
using WebApp.Entities;

namespace WebApp.Data
{
    public class EShoperDbContext : IdentityDbContext<EShoperUser>
    {
        public EShoperDbContext(DbContextOptions<EShoperDbContext> options)
            : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PhotoImage> PhotoImages { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new BrandConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new PhotoImageConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
