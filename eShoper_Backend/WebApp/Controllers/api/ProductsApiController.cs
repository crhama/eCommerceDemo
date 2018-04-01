using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApp.Entities;
using WebApp.Interfaces;
using WebApp.Models.ProductViewModels;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsApiController : Controller
    {
        private IEShoperUnit _unit;

        public ProductsApiController(IEShoperUnit unit)
        {
            _unit = unit;
        }

        [Route("HomeProductSliders")]
        public IActionResult GetSliderItems()
        {
            var sliderItems = _unit.Products.ProductItems(PageLocation.Home_Slider);
            var productDtos = Mapper.Map<IEnumerable<ProductDto>>(sliderItems);

            return Ok(productDtos);
        }

        [Route("FeatureItems")]
        public IActionResult GetFeatureItems()
        {
            var featureItems = _unit.Products.ProductItems(PageLocation.Home_Feature_Items);
            var productDtos = Mapper.Map<IEnumerable<ProductDto>>(featureItems);

            return Ok(productDtos);
        }

        [Route("RecommendedItems")]
        public IActionResult GetRecommendedItems()
        {
            var featureItems = _unit.Products.ProductItems(PageLocation.Home_Recommended_Items);

            var productDtos = Mapper.Map<IEnumerable<ProductDto>>(featureItems);

            var listOfLists = new List<List<ProductDto>>
            {
                productDtos.ToList()
            };

            return Ok(listOfLists);
        }
    }
}
