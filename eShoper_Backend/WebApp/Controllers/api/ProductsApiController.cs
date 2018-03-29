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
    [Route("api/ProductsApi")]
    public class ProductsApiController : Controller
    {
        private IEShoperUnit _unit;

        public ProductsApiController(IEShoperUnit unit)
        {
            _unit = unit;
        }

        [Route("FeatureItems")]
        public IActionResult GetFeatureItems()
        {
            var FeatureItems = _unit.Products.GetFeatureItems();
            var productDtos = Mapper.Map<IEnumerable<ProductDto>>(FeatureItems);

            return Ok(productDtos);
        }
    }
}
