using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Views.Maintenance
{
    public static class MaintenanceNavPages
    {
        public static string Brands => "Brands";
        public static string Categories => "Categories";
        public static string PhotoImages => "PhotoImages";
        public static string Products => "Products";

        public static string BrandsNavClass(ViewContext viewContext) 
            => PageNavClass(viewContext, Brands);
        public static string CategoriesNavClass(ViewContext viewContext)
            => PageNavClass(viewContext, Categories);
        public static string PhotoImagesNavClass(ViewContext viewContext)
            => PageNavClass(viewContext, PhotoImages);
        public static string ProductsNavClass(ViewContext viewContext)
            => PageNavClass(viewContext, Products);

        public static string PageNavClass(ViewContext viewContext, string controller)
        {
            var activeController = viewContext.RouteData.Values["Controller"] as string;
            return string.Equals(activeController, controller, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
