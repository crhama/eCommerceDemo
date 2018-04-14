using System.Linq;
using System.Collections.Generic;
using WebApp.Data;
using WebApp.Entities;
using WebApp.Models.ProductViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using WebApp.Models.CommonViewModels;

namespace WebApp.Repositories
{
    public class BrandRepository
        : GenericRepository<Brand>
    {
        public BrandRepository(EShoperDbContext Context) 
            : base(Context){}

        public List<BrandDto> GetBrandsWithAssociatedProductCount()
        {
            var brandDtos = GetAll()
                .Include(b => b.Products)
                .Select(b => new BrandDto
                {
                    Id = b.Id,
                    BrandName = b.BrandName,
                    ProductCount = b.Products.Count
                })
                .ToList();

            return brandDtos;                
        }

        public BrandDto GetSingleBrandWithAssociatedProductCount(int id)
        {
            var brand = Context.Brands
                .Include(b => b.Products)
                .FirstOrDefault(b => b.Id == id);
            return new BrandDto
            {
                Id = brand.Id,
                BrandName = brand.BrandName,
                ProductCount = brand.Products.Count
            };
        }

        public IEnumerable<KeyValue> GetKeyValueBrands()
        {
            var brands = GetAll()
                .OrderBy(b => b.BrandName)
                .Select(b => new KeyValue { Key = b.Id.ToString(), Value = b.BrandName })
                .ToList();
            return brands;
        }
    }
}
