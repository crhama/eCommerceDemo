using System.Collections.Generic;
using WebApp.Models.CommonViewModels;

namespace WebApp.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<KeyValue> GetCategoryKeyValueForTabDisplay();
    }
}
