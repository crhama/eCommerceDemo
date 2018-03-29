using AutoMapper;
using System.Collections.Generic;
using System.Linq;
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
            var ProductList = from p in Context.Products
                              join img in (
                                from ph in Context.PhotoImages
                                where ph.PageLocation == PageLocation.Home_Feature_Items
                                select ph
                              ) on p.Id equals img.ProductId into pjoin
                              from pj in pjoin.DefaultIfEmpty()                              
                              select new Product
                              {
                                  Id = p.Id,
                                  ProductDescription = p.ProductDescription,
                                  ProductPrice = p.ProductPrice,
                                  PromotionType = p.PromotionType,
                                  ImageId = pj.Id                                  
                              };

            

            var ProductDtoList = Mapper.Map<IEnumerable<ProductDto>>(ProductList);

            return ProductDtoList;
        }
    }
}
