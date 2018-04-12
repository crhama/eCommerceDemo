using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Interfaces;

namespace WebApp.ViewComponents
{
    public class PhotoImage : ViewComponent
    {
        private IEShoperUnit _unit;

        public PhotoImage(IEShoperUnit unit)
        {
            _unit = unit;
        }

        public IViewComponentResult Invoke(int productId)
        {
            var kvPhotos = _unit.PhotoImgs
                .GetPhotoImgsForProductDetails(productId);
            return View(kvPhotos);
        }
    }
}
