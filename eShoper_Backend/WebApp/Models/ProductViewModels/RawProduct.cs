using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;

namespace WebApp.Models.ProductViewModels
{
    public class RawProduct
    {
        public Product Product { get; set; }
        public PhotoImage PhotoImage { get; set; }
        public PageLocation PageLocation { get; set; }
    }
}
