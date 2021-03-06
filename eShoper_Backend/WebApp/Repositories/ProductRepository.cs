﻿using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebApp.Data;
using WebApp.Entities;
using WebApp.Models.MaintenanceViewModels;
using WebApp.Models.ProductViewModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApp.Repositories
{
    public class ProductRepository
        : GenericRepository<Product>
    {
        public ProductRepository(EShoperDbContext context) 
            : base(context){}

        public IEnumerable<ProductDto> GetProductsByPageLocation(PageLocation location)
        {
            var ProductList = from p in Context.Products
                              join img in (
                                from ph in Context.PhotoImages
                                where ph.PageLocation == location
                                select ph
                              ) on p.Id equals img.ProductId into pjoin
                              from pj in pjoin.DefaultIfEmpty()
                              where (
                              (location == PageLocation.Home_Feature_Items && p.IsFeatureItem.HasValue && p.IsFeatureItem.Value)
                              ||
                              (location == PageLocation.Home_Slider && p.IsSliderItem.HasValue && p.IsSliderItem.Value)
                              ||
                              (location == PageLocation.Home_Recommended_Items && p.IsRecommendedItem.HasValue && p.IsRecommendedItem.Value)
                              )
                              select new Product
                              {
                                  Id = p.Id,
                                  ProductDescription = p.ProductDescription,
                                  ProductPrice = p.ProductPrice,
                                  PromotionType = p.PromotionType,
                                  ImageId = pj.Id
                              };

            var ProductDtoList = Mapper.Map<IEnumerable<ProductDto>>(ProductList);
            var noImageString = "no-image-available";

            switch (location)
            {
                case PageLocation.Unkown_Location:
                    break;
                case PageLocation.Home_Slider:
                    noImageString = "no-image-available-sd";
                    break;
                case PageLocation.Home_Category:
                    break;
                case PageLocation.Home_Feature_Items:
                    noImageString = "no-image-available-fi";
                    break;
                case PageLocation.Home_Brands:
                    break;
                case PageLocation.Home_Tab_Categories:
                    break;
                case PageLocation.Home_Recommended_Items:
                    break;
                default:
                    break;
            }

            foreach (var dto in ProductDtoList)
            {
                dto.ImageUrl = dto.ImageUrl.Replace("__0__", noImageString);
            }

            return ProductDtoList;
        }

        public Product GetProductDetails(int id)
        {
            var product = GetAll()
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Category.ParentCategory)
                .Include(p => p.PhotoImages)
                .FirstOrDefault(p => p.Id == id);

            return product;
        }

        public IEnumerable<ProductDetailsViewModel> GetProductMaintenances()
        {
            var productList = GetAll()
                .Include(p => p.Brand).Include(p => p.Category)
                .Select(p => new ProductDetailsViewModel
                {
                    Id = p.Id,
                    ProductCode = p.ProductCode,
                    ProductDescription = p.ProductDescription,
                    ProductPrice = p.ProductPrice,
                    PromotionType = p.PromotionType,
                    BrandName = p.Brand.BrandName,
                    CategoryName = p.Category.CategoryName,
                    IsFeatureItem = p.IsFeatureItem ?? false,
                    IsRecommendedItem = p.IsRecommendedItem ?? false,
                    IsSliderItem = p.IsSliderItem ?? false
                })
                .ToList();
            return productList;
        }
    }
}
