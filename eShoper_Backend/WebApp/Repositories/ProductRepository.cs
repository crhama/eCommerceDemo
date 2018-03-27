using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Entities;
using WebApp.Models.ProductViewModels;

namespace WebApp.Repositories
{
    public class ProductRepository
        : GenericRepository<Product>
    {
        public ProductRepository(EShoperDbContext context) 
            : base(context){}

        public IEnumerable<ProductDto> GetFeatureItems()
        {
            var usageSectionId = new SqlParameter("Pagelocation", 3);
            var productList = GetAll()
                .FromSql("EXECUTE dbo.Getproductsbypagesectiontype @pagelocation", usageSectionId)
                .ToList();

            var ProductDtoList = Mapper
                .Map<IEnumerable<ProductDto>>(productList);

            return ProductDtoList;
        }
    }
}
