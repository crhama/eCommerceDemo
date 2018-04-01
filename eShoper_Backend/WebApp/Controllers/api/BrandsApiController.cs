using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;
using WebApp.Interfaces;
using WebApp.Models.ProductViewModels;

namespace WebApp.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Brands")]
    public class BrandsApiController : Controller
    {
        private IEShoperUnit _unit;

        public BrandsApiController(IEShoperUnit unit)
        {
            _unit = unit;
        }

        [Route("BrandsWithAssociatedProductCount")]
        public IActionResult GetBrandsWithAssociatedProductCount()
        {
            var brandDtos = _unit.Brands
                .GetBrandsWithAssociatedProductCount();

            return Ok(brandDtos);
        }
    }
}
