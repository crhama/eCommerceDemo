using System;
using WebApp.Interfaces;
using WebApp.Repositories;

namespace WebApp.Data
{
    public class EShoperUnit : IEShoperUnit, IDisposable
    {
        private BrandRepository _brands = null;
        private CategoryRepository _categories = null;
        private PhotoImgRepository _photoImgs = null;
        private ProductRepository _products = null;

        readonly EShoperDbContext context;
        public EShoperUnit(EShoperDbContext context)
        {
            this.context = context;
        }

        public BrandRepository Brands
        {
            get
            {
                if (_brands == null)
                {
                    _brands = new BrandRepository(context);
                }
                return _brands;
            }
        }
        public CategoryRepository Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new CategoryRepository(context);
                }
                return _categories;
            }
        }
        public PhotoImgRepository PhotoImgs
        {
            get
            {
                if (_photoImgs == null)
                {
                    _photoImgs = new PhotoImgRepository(context);
                }
                return _photoImgs;
            }
        }
        public ProductRepository Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new ProductRepository(context);
                }
                return _products;
            }
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}
