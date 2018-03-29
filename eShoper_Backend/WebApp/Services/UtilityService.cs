using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public static class UtilityService
    {
        public static string SetImageUrl(this Guid? imageId)
        {
            return $"https://localhost:44322/images/products/{imageId.ToString()}.jpg";
        }
    }
}
