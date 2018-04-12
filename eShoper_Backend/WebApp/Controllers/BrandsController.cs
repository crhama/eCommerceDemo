using Microsoft.AspNetCore.Mvc;
using WebApp.Interfaces;
using WebApp.Models.CommonViewModels;

namespace WebApp.Controllers
{
    public class BrandsController : Controller
    {
        private IEShoperUnit _unit;

        public BrandsController(IEShoperUnit unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            ViewBag.MaintenanceHeader =
                new KeyValue { Key = "Products", Value = "Details" };

            var brands = _unit.Brands.GetAll();
            return View(brands);
        }
    }
}
