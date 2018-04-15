using Microsoft.AspNetCore.Mvc;
using WebApp.Interfaces;

namespace WebApp.Controllers
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

        [Route("TabProductsByCategory/{category}")]
        public IActionResult GetTabProductsByCategory(string category)
        {
            var tabProductsByCategory = _categoryService
                    .GetTabProductsByCategory(category);
            return Ok(tabProductsByCategory);
        }
    }
}
