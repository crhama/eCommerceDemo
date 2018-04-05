using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApp.Entities;
using WebApp.Interfaces;
using WebApp.Models.MaintenanceViewModels;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private IEShoperUnit _unit;

        public ProductsController(IEShoperUnit unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            var productList = _unit.Products
                .GetProductMaintenances();
            return View(productList);
        }

        public IActionResult Details(int id)
        {
            return View("AddEdit");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Brands = _unit.Brands.GetKeyValueBrands();
            ViewBag.Categories = _unit.Categories.GetCategoriesForDDL();
            ViewBag.PromotionTypes = UtilityService
                .GetKeyValueFromEnum<PromotionType>();

            var product = _unit.Products.GetById(id);
            var vm = Mapper.Map<ProductViewModel>(product);
            return View("AddEdit", vm);
        }

        public IActionResult Add()
        {
            ViewBag.Brands = _unit.Brands.GetKeyValueBrands();
            ViewBag.Categories = _unit.Categories.GetCategoriesForDDL();
            ViewBag.PromotionTypes = UtilityService
                .GetKeyValueFromEnum<PromotionType>();

            return View("AddEdit");
        }
    }
}
