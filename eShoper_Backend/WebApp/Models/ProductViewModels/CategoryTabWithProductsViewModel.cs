using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.CommonViewModels;

namespace WebApp.Models.ProductViewModels
{
    public class CategoryTabWithProductsViewModel
    {
        public List<string> SelectedCategoryList { get; set; }
        public IEnumerable<ProductDto> FirstListOfProducts { get; set; }
    }
}
