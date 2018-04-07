using Microsoft.AspNetCore.Mvc;
using WebApp.Interfaces;

namespace WebApp.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Categories")]
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
