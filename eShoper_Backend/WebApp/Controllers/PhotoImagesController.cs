using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;
using WebApp.Interfaces;
using WebApp.Models.CommonViewModels;
using WebApp.Services;

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

        [HttpGet]
        public IActionResult Details(string id, int productId, string pagelocation)
        {
            ViewBag.MaintenanceHeader =
                new KeyValue { Key = "Photo", Value = "Product's photo" };

            bool imageExistId = false;

            if (Guid.TryParse(id, out Guid fileId))
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                string path = Path.Combine(webRootPath, "images/maintenance", fileId.ToString() + ".jpg");
                if (System.IO.File.Exists(path))
                {
                    imageExistId = true;
                }
            }

            var location = Enum.TryParse(typeof(PageLocation), pagelocation, out object result)
                        ? (PageLocation)result : PageLocation.Unkown_Location;

            ViewBag.PageLocations = _unit.PhotoImgs
                .GetPossibleLocationForImageDownsizing(productId, location);

            var photo = (imageExistId)
                        ? _unit.PhotoImgs.GetImageDetailsById(fileId)
                        : new PhotoImage
                        {
                            Id = Guid.Empty,
                            PageLocation = location,
                            ProductId = productId
                        };

            return View(photo);
        }

        [HttpPost]
        public IActionResult UploadProductImage(
                                            IFormFile file,
                                            int productId,
                                            PageLocation pagelocation)
        {

            PhotoImage existingImage = _unit.PhotoImgs
                .GetImageByProductAndPageLocation(productId, pagelocation);

            var photoId = Guid.NewGuid();
            if (existingImage != null)
            {
                photoId = existingImage.Id;
            }

            string webRootPath = _hostingEnvironment.WebRootPath;
            string filePath = Path.Combine(
                                            webRootPath,
                                            "images/maintenance",
                                            photoId.ToString() +
                                            file.GetFileExtension());
            try
            {
                var photo = new PhotoImage();

                if (existingImage != null
                    && System.IO.File.Exists(filePath))
                {
                    photo = existingImage;

                    if (System.IO.File.Exists(filePath + "__"))
                        System.IO.File.Delete(filePath + "__");

                    System.IO.File.Move(filePath, filePath + "__");
                }
                else
                {
                    photo.Id = photoId;
                    photo.ProductId = productId;
                    photo.PageLocation = pagelocation;                    
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                photo.OriginalName = file.FileName;
                photo.FileExtension = file.ContentType;

                using (var image = new MagickImage(filePath))
                {
                    photo.Width = image.Width;
                    photo.Height = image.Height;
                    photo.Resolution = image.Quality;
                }

                if (existingImage != null)
                    _unit.PhotoImgs.Update(photo);
                else
                    _unit.PhotoImgs.Add(photo);

                _unit.SaveChanges();

                TempData["fileUploadSucces"]  = JsonConvert.SerializeObject(
                     new KeyValuePair<bool, string>(true, "Image successfully added."));

            }
            catch (Exception)
            {
                if (existingImage != null
                    && System.IO.File.Exists(filePath + "__"))
                {
                    System.IO.File.Move(filePath + "__", filePath);
                }

                TempData["fileUploadSucces"] = JsonConvert.SerializeObject(
                     new KeyValuePair<bool, string>(false, "Image upload failed."));
            }

            return RedirectToAction(nameof(Details), 
                            new { id = photoId.ToString(),
                                pagelocation = pagelocation.ToString(),
                                productId
                            });
        }

    }
}
