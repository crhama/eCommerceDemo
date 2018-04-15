using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Interfaces;
using WebApp.Models.CommonViewModels;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Brands")]
    public class BrandsApiController : Controller
    {
        private IEShoperUnit _unit;

        public BrandsApiController(IEShoperUnit unit)
        {
            _unit = unit;
        }

        [Route("BrandsWithAssociatedProductCount")]
        public IActionResult GetBrandsWithAssociatedProductCount()
        {
            var brandDtos = _unit.Brands
                .GetBrandsWithAssociatedProductCount();

            return Ok(brandDtos);
        }

        [Route("BrandMaintenanceTable")]
        public IActionResult GetBrandMaintenanceTable()
        {
            var tableData = new List<List<KeyValue>>
            {
                new List<KeyValue>
                {
                    new KeyValue { Key = "Id", Value = "Id" },
                    new KeyValue { Key = "BrandName", Value = "Brand" }
                },
                new List<KeyValue>
                {
                    new KeyValue { Key = "Id", Value = "1" },
                    new KeyValue { Key = "BrandName", Value = "Anne Klein" }
                },
                new List<KeyValue>
                {
                    new KeyValue { Key = "Id", Value = "2" },
                    new KeyValue { Key = "BrandName", Value = "Georgio Armani" }
                },
                new List<KeyValue>
                {
                    new KeyValue { Key = "Id", Value = "3" },
                    new KeyValue { Key = "BrandName", Value = "Belle" }
                }
            };

            return Ok(tableData);
        }
    }
}
