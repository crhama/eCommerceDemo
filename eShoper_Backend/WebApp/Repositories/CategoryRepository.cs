using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApp.Data;
using WebApp.Entities;
using WebApp.Models.ProductViewModels;

namespace WebApp.Repositories
{
    public class CategoryRepository
        : GenericRepository<Category>
    {
        public CategoryRepository(EShoperDbContext Context) 
            : base(Context){}

        public IEnumerable<CategoryDto> CategoryForMenuDisplay()
        {
            var categoyList = GetAll()
                .Include(c => c.ChildrenCategory)
                .Where(c => c.Level == 1)
                .ToList();

            var CategoryDtoList = Mapper.Map<IEnumerable<CategoryDto>>(categoyList);
         
            return CategoryDtoList;
        }
    }
}
