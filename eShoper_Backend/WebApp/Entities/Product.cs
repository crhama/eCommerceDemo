using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public PromotionType PromotionType { get; set; }
        public Guid? ImageId { get; set; }

        public Brand Brand { get; set; }
        public Category Category { get; set; }

        public ICollection<PhotoImage> PhotoImages { get; set; }
                                        = new List<PhotoImage>();
    }
}
