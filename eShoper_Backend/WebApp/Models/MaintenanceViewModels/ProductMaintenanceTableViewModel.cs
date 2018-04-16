using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.CommonViewModels;

namespace WebApp.Models.MaintenanceViewModels
{
    public class ProductMaintenanceTableViewModel
    {
        public KeyValueWidth[] HeaderKV { get; set; }
        public KeyValue[][] BodyKV { get; set; }
    }
}
