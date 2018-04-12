using Microsoft.AspNetCore.Mvc;
using WebApp.Interfaces;
using WebApp.Models.CommonViewModels;

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
            ViewBag.MaintenanceHeader =
                new KeyValue { Key = "Products", Value = "Details" };

            var categories = _unit.Categories.GetCategoriesForMaintenance();
            return View(categories);
        }
    }
}
