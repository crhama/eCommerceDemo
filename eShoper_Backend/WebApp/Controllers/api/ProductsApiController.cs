using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApp.Entities;
using WebApp.Interfaces;
using WebApp.Models.CommonViewModels;
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

        [Route("ProductMaintenanceTable")]
        public IActionResult GetProductMaintenanceTable()
        {
            var tableData = new List<List<KeyValue>>
            {
                new List<KeyValue>
                {
                    new KeyValue { Key = "Id", Value = "Id" },
                    new KeyValue { Key = "ProductCode", Value = "Code" },
                    new KeyValue { Key = "ProductDescription", Value = "Description" },
                    new KeyValue { Key = "ProductPrice", Value = "Price" },
                    new KeyValue { Key = "BrandId", Value = "Brand" },
                    new KeyValue { Key = "Category1", Value = "Category 1" },
                    new KeyValue { Key = "Category2", Value = "Category 2" },
                    new KeyValue { Key = "PromotionType", Value = "Promotion" }
                },
                new List<KeyValue>
                {
                    new KeyValue { Key = "Id", Value = "1" },
                    new KeyValue { Key = "ProductCode", Value = "WDRE-1" },
                    new KeyValue { Key = "ProductDescription", Value = "Anne Klein Sleeveless Colorblock Scuba" },
                    new KeyValue { Key = "ProductPrice", Value = "$59.99" },
                    new KeyValue { Key = "BrandId", Value = "Anne Klein" },
                    new KeyValue { Key = "Category1", Value = "Women" },
                    new KeyValue { Key = "Category2", Value = "Dress" },
                    new KeyValue { Key = "PromotionType", Value = "Normal" }
                }
            };

            return Ok(tableData);
        }
    }
}
