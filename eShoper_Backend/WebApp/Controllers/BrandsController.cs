using Microsoft.AspNetCore.Mvc;
using WebApp.Interfaces;

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
            var brands = _unit.Brands.GetAll();
            return View(brands);
        }
    }
}
