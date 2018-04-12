using Microsoft.AspNetCore.Mvc;
using WebApp.Entities;
using WebApp.Interfaces;
using WebApp.Services;
using System;
using WebApp.Models.CommonViewModels;

namespace WebApp.Controllers
{
    public class PhotoImagesController : Controller
    {
        private IEShoperUnit _unit;

        public PhotoImagesController(IEShoperUnit unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            ViewBag.MaintenanceHeader =
                new KeyValue { Key = "Products", Value = "Details" };

            return View();
        }

        public IActionResult Details(int productId, string id)
        {
            ViewBag.PageLocations = UtilityService
                .GetKeyValueFromEnum<PageLocation>();
            ViewBag.MaintenanceHeader =
                new KeyValue { Key = "Products", Value = "Details" };

            Guid guidId = Guid.Empty;
            PageLocation pageLocation = PageLocation.Unkown_Location;
            bool idIsGuid = false;


            switch (id)
            {
                case string guidStr when (Guid.TryParse(id, out Guid enumGuid)):
                    guidId = enumGuid;
                    idIsGuid = true;
                    break;

                case string enumStr when (Enum.TryParse(typeof(PageLocation), id, out object result)):
                    pageLocation = (PageLocation)result;
                    break;
            }

            var photo = (idIsGuid)
                        ? _unit.PhotoImgs.GetImageDetailsById(guidId)
                        : new PhotoImage
                        {
                            PageLocation = (PageLocation)pageLocation
                        };

            return View(photo);
        }
    }
}
