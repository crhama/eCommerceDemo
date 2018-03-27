using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
