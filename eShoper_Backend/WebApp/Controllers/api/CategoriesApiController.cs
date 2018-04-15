using Microsoft.AspNetCore.Mvc;
using WebApp.Interfaces;

namespace WebApp.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesApiController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesApiController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("CategoriesForTabDisplay")]
        public IActionResult GetCategoriesForTabDisplay()
        {
            var categoriesForTabDisplay = _categoryService
                    .GetCategoryKeyValueForTabDisplay();

            return Ok(categoriesForTabDisplay);
        }
    }
}
