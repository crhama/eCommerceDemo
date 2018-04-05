using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.MaintenanceViewModels
{
    public class CategoryMaintenance
    {
        public int Id { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public string ParentCategoryName { get; set; }
        public int NumberOfProducts { get; set; }
    }
}
