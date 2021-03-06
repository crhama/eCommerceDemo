﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities;
using WebApp.Models.CommonViewModels;
using WebApp.Models.ProductViewModels;

namespace WebApp.Services
{
    public static class UtilityService
    {
        public static string SetImageUrl(this Guid? imageId)
        {
            return (imageId.HasValue) 
                ? $"https://localhost:44322/images/src/{imageId.ToString()}.jpg"
                : $"https://localhost:44322/images/src/__0__.jpg";
        }

        public static string SetImageUrl(this Guid imageId)
        {
            return (imageId == Guid.Empty) 
                ? $"https://localhost:44322/images/maintenance/no-image-available.jpg"
                : $"https://localhost:44322/images/maintenance/{imageId.ToString()}.jpg";
        }

        public static string SetImageUrl(this string strImageId, string folder = "src")
        {
            return (Guid.TryParse(strImageId, out Guid imageId)) ? 
                $"https://localhost:44322/images/{folder}/{imageId.ToString()}.jpg"
                : $"https://localhost:44322/images/{folder}/no-image-available.jpg";
        }

        public static IEnumerable<ProductDto> SetImageUrl(this IEnumerable<ProductDto> productDtos)
        {
            foreach (var dto in productDtos)
            {
                dto.ImageUrl = SetImageUrl(dto.ImageUrl);
            }

            return productDtos;
        }

        public static bool IsConvertibleTo<T>(this string value)
        {
            if (typeof(T) == typeof(Guid))
                return Guid.TryParse(value, out Guid id);
            else
                return false;
        }

        public static IEnumerable<KeyValue> GetKeyValueVisualLocations()
        {
            string[] valueToExclude =  ExtractStringFromEnum(
                                  PageLocation.Unkown_Location,
                                  PageLocation.Home_Brands,
                                  PageLocation.Home_Category);

            return GetKeyValueFromEnum<PageLocation>()
                .Where(l => !valueToExclude.Contains(l.Value));
        }

        public static IEnumerable<KeyValue> GetKeyValueFromEnum<T>()
        {
            var kvList = new List<KeyValue>();
            foreach (int i in Enum.GetValues(typeof(T)))
            {
                String name = Enum.GetName(typeof(T), i);
                var kv = new KeyValue
                {
                    Key = i.ToString(),
                    Value = name
                };
                kvList.Add(kv);
            }
            return kvList;
        }

        public static string[] ExtractStringFromEnum<T>(params T[] items)             
        {
            var list = new List<string>();

            foreach (int i in Enum.GetValues(typeof(T)))
            {
                String name = Enum.GetName(typeof(T), i);
                var item = items.FirstOrDefault(e => e.ToString().ToLower()
                                            == name.ToLower());
                if (!list.Contains(item.ToString()))
                    list.Add(name);
            }

            return list.ToArray();
        }

        public static string DisplayEmptyStringIfDefault(this Guid id)
        {
            return (EqualityComparer<Guid>.Default.Equals(id, default(Guid)))
                ? "" : id.ToString();
        }

        public static string GetFileExtension(this IFormFile file)
        {
            return ".jpg";
        }

        public static string GetFileExtension(this string originalName)
        {
            string extension = System.IO.Path.GetExtension(originalName);
            return extension;
        }

        public static IEnumerable<ImageWeightInfo> GetPageLocationWeighting()
        {
            var listOfImageInfos = new List<ImageWeightInfo>
            {
                new ImageWeightInfo
                {
                    Id = 1, PageLocation = PageLocation.Home_Slider,
                    Width = 484, Height = 441, Resolution = 96, SizeOrder = 1
                },
                new ImageWeightInfo
                {
                    Id = 3, PageLocation = PageLocation.Home_Feature_Items,
                    Width = 268, Height = 249, Resolution = 96, SizeOrder = 2
                },
                new ImageWeightInfo
                {
                    Id = 5, PageLocation = PageLocation.Home_Tab_Categories,
                    Width = 208, Height = 183, Resolution = 96, SizeOrder = 2
                }
            };

            return listOfImageInfos;
        }
    }
}
