using System.Collections.Generic;
using WebApp.Models.ProductViewModels;

namespace WebApp.Interfaces
{
    public interface ICategoryService
    {
        CategoryTabWithProductsViewModel GetCategoryKeyValueForTabDisplay();
        IEnumerable<ProductDto> GetTabProductsByCategory(string category);
    }
}
