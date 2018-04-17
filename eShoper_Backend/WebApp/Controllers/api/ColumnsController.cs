using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.MaintenanceViewModels;

namespace WebApp.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Columns")]
    public class ColumnsController : Controller
    {
        [Route("ColumnsForDisplay")]
        public IActionResult GetColumnsForDisplay()
        {
            ColumnViewModel[] columnListVM = {
              new ColumnViewModel { Id = 1, ColumnName = "Id", IsSelectable = false, IsSelected = true },
              new ColumnViewModel { Id = 2, ColumnName = "ProductCode", IsSelectable = false, IsSelected = true },
              new ColumnViewModel { Id = 3, ColumnName = "ProductDescription", IsSelectable = false, IsSelected = true }
            };

            return Ok(columnListVM);
        }
    }
}
