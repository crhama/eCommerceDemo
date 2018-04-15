using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Interfaces;
using WebApp.Models.CommonViewModels;
using WebApp.Models.ProductViewModels;

namespace WebApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IEShoperUnit _unit;
        public CategoryService(IEShoperUnit unit)
        {
            _unit = unit;
        }

        public CategoryTabWithProductsViewModel GetCategoryKeyValueForTabDisplay()
        {
            var CategoryNames = _unit.Categories.GetAll()
                .Where(c => c.Level == 2)
                .Select(c => c.CategoryName).Distinct()
                .ToList();
            var rnd = new Random();
            var namesRanked = CategoryNames
                    .OrderBy(x => rnd.Next()).Take(4)
                    .ToList();

            string firstCategoryName = namesRanked[0];

            var productDtos = (from p in _unit.Products.GetAll().Where(p =>
                                p.Category.CategoryName == firstCategoryName)
                           join img in _unit.PhotoImgs.GetAll()
                           on p.Id equals img.ProductId into pimgjoin
                           from pimg in pimgjoin.DefaultIfEmpty()
                           select new ProductDto
                           {
                               Id = p.Id,
                               ProductDescription = p.ProductDescription,
                               PromotionType = p.PromotionType,
                               ProductPrice = p.ProductPrice,
                               ImageUrl = (pimg == null) ? string.Empty : pimg.Id.ToString()
                            })
                            .ToList();

            foreach (var dto in productDtos)
            {
                dto.ImageUrl = UtilityService.SetImageUrl(dto.ImageUrl);
            }

            var vm = new CategoryTabWithProductsViewModel
            {
                SelectedCategoryList = namesRanked,
                FirstListOfProducts = productDtos
            };


            return vm;
        }
    }
}
