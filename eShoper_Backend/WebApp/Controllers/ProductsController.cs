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
            var product = _unit.Products.GetProductDetails(id);
            ViewBag.H2Title = "Products";
            ViewBag.H4Title = $"Details { product.ProductCode }";
            var vm = Mapper.Map<ProductDetailsViewModel>(product);

            return View(vm);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Brands = _unit.Brands.GetKeyValueBrands();
            ViewBag.Categories = _unit.Categories.GetCategoriesForDDL();
            ViewBag.PromotionTypes = UtilityService
                .GetKeyValueFromEnum<PromotionType>();

            var product = _unit.Products.GetById(id);

            ViewBag.H2Title = "Products";
            ViewBag.H4Title = $"Edit { product.ProductCode }";
            
            var vm = Mapper.Map<ProductViewModel>(product);
            return View("AddEdit", vm);
        }

        public IActionResult Add()
        {
            ViewBag.H2Title = "Products";
            ViewBag.H4Title = "Add new product";

            ViewBag.Brands = _unit.Brands.GetKeyValueBrands();
            ViewBag.Categories = _unit.Categories.GetCategoriesForDDL();
            ViewBag.PromotionTypes = UtilityService
                .GetKeyValueFromEnum<PromotionType>();

            return View("AddEdit", new ProductViewModel());
        }

        [HttpPost]
        public IActionResult AddEdit(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Brands = _unit.Brands.GetKeyValueBrands();
                ViewBag.Categories = _unit.Categories.GetCategoriesForDDL();
                ViewBag.PromotionTypes = UtilityService
                    .GetKeyValueFromEnum<PromotionType>();

                return View(model);
            }

            Product product = Mapper.Map<Product>(model);

            _unit.Products.Add(product);
            _unit.SaveChanges();

            return RedirectToAction("Details", new { id = product.Id });
        }
    }
}
