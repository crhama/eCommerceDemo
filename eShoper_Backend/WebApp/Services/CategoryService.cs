using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Interfaces;
using WebApp.Models.CommonViewModels;

namespace WebApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IEShoperUnit _unit;
        public CategoryService(IEShoperUnit unit)
        {
            _unit = unit;
        }

        public IEnumerable<KeyValue> GetCategoryKeyValueForTabDisplay()
        {
            var CategoryNames = _unit.Categories.GetAll()
                .Where(c => c.Level == 2)
                .Select(c => c.CategoryName).Distinct()
                .ToList();
            var rnd = new Random();
            var namesRanked = CategoryNames
                    .OrderBy(x => rnd.Next()).Take(4)
                    .Select(kv => new KeyValue { Key = "1", Value = kv })
                    .ToList();
            return namesRanked;
        }
    }
}
