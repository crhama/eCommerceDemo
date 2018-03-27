using System;
using System.Collections.Generic;

namespace WebApp.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
        public int? Level { get; set; }
        public string CategoryCode { get; set; }

        public Category ParentCategory { get; set; }
        public IList<Category> ChildrenCategory { get; set; } = new List<Category>();
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
