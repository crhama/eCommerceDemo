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
    }
}
