using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.MaintenanceViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        [Required]
        [MaxLength(37)]
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public PromotionType PromotionType { get; set; }

        public bool IsSliderItem { get; set; }
        public bool IsFeatureItem { get; set; }
        public bool IsRecommendedItem { get; set; }
    }
}
