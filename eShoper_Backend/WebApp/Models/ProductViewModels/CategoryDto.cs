using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.ProductViewModels
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
        public string CategoryCode { get; set; }

        public List<CategoryDto> ChildrenCategory { get; set; } 
            = new List<CategoryDto>();
    }
}
