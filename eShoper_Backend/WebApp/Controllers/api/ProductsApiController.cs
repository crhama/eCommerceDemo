using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApp.Entities;
using WebApp.Interfaces;
using WebApp.Models.CommonViewModels;
using WebApp.Models.MaintenanceViewModels;
using WebApp.Models.ProductViewModels;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsApiController : Controller
    {
        private readonly IProductService _productservice;

        public ProductsApiController(IProductService productservice)
        {
            _productservice = productservice;
        }

        [Route("HomeProductSliders")]
        public IActionResult GetSliderItems()
        {
            var productDtos = _productservice.GetProductDtosForHomeSlider();
            return Ok(productDtos);
        }

        [Route("FeatureItems")]
        public IActionResult GetFeatureItems()
        {
            var productDtos = _productservice
                .GetProductDtosForFeatureItems();
            return Ok(productDtos);
        }

        [Route("RecommendedItems")]
        public IActionResult GetRecommendedItems()
        {
            var productDtos = _productservice
                .GetProductDtosForRecommendedItems();
            return Ok(productDtos);
        }

        [Route("ProductMaintenanceTable")]
        public IActionResult GetProductMaintenanceTable()
        {
            var vm = new ProductMaintenanceTableViewModel();
            vm.HeaderKV = new List<KeyValueWidth>{
               new KeyValueWidth { Key = "Id", Value = "", Width = 50 },
               new KeyValueWidth { Key = "ProductCode", Value = "Code", Width = 232 },
               new KeyValueWidth { Key = "ProductDescription", Value = "Description", Width = 382 },
               new KeyValueWidth { Key = "ProductPrice", Value = "Price", Width = 170 },
               new KeyValueWidth { Key = "PromotionType", Value = "Promotion", Width = 66 },
               new KeyValueWidth { Key = "BrandId", Value = "Brand", Width = 129 },
               new KeyValueWidth { Key = "CategoryId", Value = "Category", Width = 104 }
            }.ToArray();
            
            var row = new List<KeyValue>
            {
                new KeyValue { Key = "Id", Value = "" },
                new KeyValue { Key = "ProductCode", Value = "WDRE-1" },
                new KeyValue { Key = "ProductDescription", Value = "Anne Klein Sleeveless Colorblock Scuba" },
                new KeyValue { Key = "ProductPrice", Value = "$59.99" },
                new KeyValue { Key = "PromotionType", Value = "New" },
                new KeyValue { Key = "BrandId", Value = "Anne Klein" },
                new KeyValue { Key = "CategoryId", Value = "Dress" }
            }.ToArray();

            vm.BodyKV = new List<KeyValue[]>
            {
                row
            }.ToArray();
            return Ok(vm);
        }
    }
}
