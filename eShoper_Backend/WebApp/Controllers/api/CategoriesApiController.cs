using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Interfaces;
using WebApp.Models.ProductViewModels;

namespace WebApp.Controllers.api
{
    [Produces("application/json")]
    [Route("api/CategoriesApi")]
    public class CategoriesApiController : Controller
    {
        private IEShoperUnit _unit;

        public CategoriesApiController(IEShoperUnit unit)
        {
            _unit = unit;
        }

        [Route("CategoriesForExistingProducts")]
        public IActionResult GetCategoriesForExistingProducts()
        {
            var categoryDtoList = _unit.Categories
                .GetCategoriesForExistingProducts();

            return Ok(categoryDtoList);
        }
    }
}
