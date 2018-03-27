using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.ProductViewModels
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public string CategoryCode { get; set; }

        public List<CategoryDto> ChildrenCategory { get; } 
            = new List<CategoryDto>();
    }
}
