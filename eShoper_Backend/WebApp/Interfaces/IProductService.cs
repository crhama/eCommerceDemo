using System.Collections.Generic;
using WebApp.Models.ProductViewModels;

namespace WebApp.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProductDtosForHomeSlider();
        IEnumerable<ProductDto> GetProductDtosForFeatureItems();
        IEnumerable<ProductDto> GetProductDtosForRecommendedItems();
    }
}
