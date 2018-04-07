using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Models.MaintenanceViewModels
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }
        [Display(Name = "Description")]
        public string ProductDescription { get; set; }
        [Display(Name = "Price")]
        public decimal ProductPrice { get; set; }
        public PromotionType PromotionType { get; set; }
        [Display(Name = "Brand")]
        public string BrandName { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        [Display(Name = "Is Featured")]
        public bool IsFeatureItem { get; set; }
        [Display(Name = "Is Recommended")]
        public bool IsRecommendedItem { get; set; }
        [Display(Name = "Is Slider")]
        public bool IsSliderItem { get; set; }
    }
}
