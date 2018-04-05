using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PhotoImagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
