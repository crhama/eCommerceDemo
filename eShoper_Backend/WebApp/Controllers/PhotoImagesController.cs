using Microsoft.AspNetCore.Mvc;
using WebApp.Entities;
using WebApp.Interfaces;
using WebApp.Services;
using System;
using WebApp.Models.CommonViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApp.Controllers
{
    public class PhotoImagesController : Controller
    {
        private readonly IEShoperUnit _unit;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PhotoImagesController(
            IEShoperUnit unit,
            IHostingEnvironment hostingEnvironment)
        {
            _unit = unit;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            ViewBag.MaintenanceHeader =
                new KeyValue { Key = "Products", Value = "Details" };

            return View();
        }

        public IActionResult Details(string id, int productId, string pagelocation)
        {
            ViewBag.PageLocations = UtilityService
                .GetKeyValueFromEnum<PageLocation>();
            ViewBag.MaintenanceHeader =
                new KeyValue { Key = "Photo", Value = "Product's photo" };

            bool imageExistId = false;

            if (Guid.TryParse(id, out Guid fileId))
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                string path = Path.Combine(webRootPath, "images/products", fileId.ToString() + ".jpg");
                if(System.IO.File.Exists(path))
                {
                    imageExistId = true;
                }
            }

            var location = Enum.TryParse(typeof(PageLocation), pagelocation, out object result)
                        ? (PageLocation)result : PageLocation.Unkown_Location;

            var photo = (imageExistId)
                        ? _unit.PhotoImgs.GetImageDetailsById(fileId)
                        : new PhotoImage
                        {
                            Id = Guid.Empty,
                            PageLocation = location
                        };

            return View(photo);
        }

        public async Task<IActionResult> UploadProductImage(
                                            IFormFile file, 
                                            int productId,
                                            PageLocation pagelocation)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var photoId = Guid.NewGuid();
            string filePath = Path.Combine(
                                            webRootPath,
                                            "images/tests",
                                            photoId.ToString());

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var photo = new PhotoImage
            {
                Id = photoId,
                ProductId = productId,
                PageLocation = pagelocation,
                OriginalName = file.FileName,
                FileExtension = file.ContentType               
            };


            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            //var obj = new { id = , productId = productId, pagelocation  = pagelocation };

            //return RedirectToAction("Details", obj);

            return Ok(new { webRootPath });
        }
    }
}
