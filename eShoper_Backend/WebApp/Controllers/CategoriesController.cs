using Microsoft.AspNetCore.Mvc;
using WebApp.Interfaces;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private IEShoperUnit _unit;

        public CategoriesController(IEShoperUnit unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            var categories = _unit.Categories.GetCategoriesForMaintenance();
            return View(categories);
        }
    }
}
