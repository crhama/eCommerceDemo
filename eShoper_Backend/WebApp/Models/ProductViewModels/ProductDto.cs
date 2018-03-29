using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Models.ProductViewModels
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductDescription { get; set; }
        public PromotionType PromotionType { get; set; }
        public decimal ProductPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}
