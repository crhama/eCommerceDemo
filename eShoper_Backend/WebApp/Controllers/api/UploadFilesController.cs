using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.api
{
    public class UploadFilesController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public UploadFilesController(
            IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;

            string filePath = Path.Combine(
                                            webRootPath,
                                            "images/tests",
                                            file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { webRootPath });
        }
    }
}