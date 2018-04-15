using AutoMapper;
using System.Collections.Generic;
using WebApp.Entities;
using WebApp.Interfaces;
using WebApp.Models.ProductViewModels;

namespace WebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IEShoperUnit _unit;

        public ProductService(IEShoperUnit unit)
        {
            _unit = unit;
        }

        public IEnumerable<ProductDto> GetProductDtosForFeatureItems()
        {
            return GetProductDtosByLocation(PageLocation.Home_Feature_Items);
        }

        public IEnumerable<ProductDto> GetProductDtosForHomeSlider()
        {
            return GetProductDtosByLocation(PageLocation.Home_Slider);
        }

        private IEnumerable<ProductDto> GetProductDtosByLocation(PageLocation pageLocation)
        {
            var sliderItems = _unit.Products.GetProductsByPageLocation(pageLocation);
            var productDtos = Mapper.Map<IEnumerable<ProductDto>>(sliderItems);
            return productDtos;
        }
    }
}
