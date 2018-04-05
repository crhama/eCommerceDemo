using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Models.MaintenanceViewModels
{
    public class ProductMaintenance
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public PromotionType PromotionType { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public bool? IsFeatureItem { get; set; }
        public bool? IsRecommendedItem { get; set; }
        public bool? IsSliderItem { get; set; }
    }
}
