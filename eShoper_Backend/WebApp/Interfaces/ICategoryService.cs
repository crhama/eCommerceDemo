using WebApp.Models.ProductViewModels;

namespace WebApp.Interfaces
{
    public interface ICategoryService
    {
        CategoryTabWithProductsViewModel GetCategoryKeyValueForTabDisplay();
    }
}
