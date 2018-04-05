using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Data;
using WebApp.Entities;
using WebApp.Models.CommonViewModels;
using WebApp.Models.MaintenanceViewModels;
using WebApp.Models.ProductViewModels;

namespace WebApp.Repositories
{
    public class CategoryRepository
        : GenericRepository<Category>
    {
        public CategoryRepository(EShoperDbContext Context) 
            : base(Context){}

        public IEnumerable<CategoryDto> GetCategoriesForExistingProducts()
        {            
            var categoyList = GetAll().Include(c => c.ChildrenCategory)
                                      .Where(c => c.Level == 1)
                                      .ToList();

            var CategoryDtoList = Mapper.Map<IEnumerable<CategoryDto>>(categoyList);
         
            return CategoryDtoList;
        }

        public IEnumerable<KeyValue> GetCategoriesForDDL()
        {
            var categories = GetAll().Include(c => c.ParentCategory)
                .Where(c => c.Level == 2)
                .OrderBy(c => c.ParentCategory.CategoryName)
                .ThenBy(c => c.CategoryName)
                .Select(c => new KeyValue {
                    Key = c.Id.ToString(),
                    Value = $"{c.CategoryName} ({c.ParentCategory.CategoryName})"
                })
                .ToList();
            return categories;
        }

        public IEnumerable<CategoryMaintenance> GetCategoriesForMaintenance()
        {
            var categoryList = GetAll().Include(c => c.ParentCategory)
                                .Where(c => c.Level == 2)
                                .Select( c => new CategoryMaintenance {
                                    Id = c.Id,
                                    CategoryCode = c.CategoryCode,
                                    CategoryName = c.CategoryName,
                                    ParentCategoryName = c.ParentCategory.CategoryName,
                                    NumberOfProducts = c.Products.Count
                                })
                                .OrderBy(c => c.ParentCategoryName)
                                .ThenBy(c => c.CategoryName)
                                .ToList();

             return categoryList;
        }
    }
}
