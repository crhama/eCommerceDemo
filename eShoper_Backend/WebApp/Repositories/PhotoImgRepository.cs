using System.Linq;
using System.Collections.Generic;
using WebApp.Data;
using WebApp.Entities;
using Microsoft.EntityFrameworkCore;
using WebApp.Services;
using WebApp.Models.CommonViewModels;
using System;
using WebApp.Models.MaintenanceViewModels;

namespace WebApp.Repositories
{
    public class PhotoImgRepository
        : GenericRepository<PhotoImage>
    {
        public PhotoImgRepository(EShoperDbContext Context) 
            : base(Context){}

        public IEnumerable<PhotoByProductViewModel> GetPhotoImgsForProductDetails(int productId)
        {
            if(Context.Products.Any(p => p.Id == productId))
            {
                var photoByLoc = from loc in UtilityService
                        .GetKeyValueVisualLocations()
                        join ph in GetAll()                        
                        on loc.Value.ToLower() equals                        
                        ph.PageLocation.ToString().ToLower()                        
                        into locjoin
                        from l in locjoin.Where(p => p.ProductId == productId)
                                         .DefaultIfEmpty()
                        select new PhotoByProductViewModel
                        {
                            Id = l == null ? "" : l.Id.ToString(),
                            ProductId = productId,
                            PageLocation = loc.Value
                        };

                return photoByLoc;
            }
            else
            {
                return new List<PhotoByProductViewModel>();
            }
        }

        public PhotoImage GetImageDetailsById(Guid id)
        {
            PhotoImage img = GetAll()
                    .FirstOrDefault(i => i.Id == id);
            return img;
        }

        public PhotoImage GetImageByProductAndPageLocation
                (int productId, PageLocation pagelocation)
        {
            return Context.PhotoImages
                .FirstOrDefault(ph => ph.ProductId == productId
                                   && ph.PageLocation == pagelocation);
        }

        public IEnumerable<KeyValue> GetPossibleLocationForImageDownsizing(
            int productId, PageLocation location)
        {
            var loc = UtilityService.GetPageLocationWeighting()
                        .FirstOrDefault(l => l.PageLocation == location);
            var listofPageLocs = UtilityService.GetPageLocationWeighting()
                        .Where(l => l.SizeOrder < loc.SizeOrder)
                        .Select(l => l.PageLocation)
                        .ToList();

            var locs = GetAll().Where(ph => ph.ProductId == productId &&
                                 listofPageLocs.Contains(ph.PageLocation))
                               .Select(ph => ph.PageLocation)
                               .ToList();

            var listOfLocs = new List<KeyValue>();
            foreach (var item in locs)
            {
                listOfLocs.Add(new KeyValue {
                    Key = ((int)item).ToString(),
                    Value = item.ToString()
                });
            }
            return listOfLocs;
        }
    }
}
