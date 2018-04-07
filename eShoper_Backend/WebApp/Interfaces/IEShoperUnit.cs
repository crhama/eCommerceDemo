using WebApp.Repositories;

namespace WebApp.Interfaces
{
    public interface IEShoperUnit
    {
        BrandRepository Brands { get; }
        CategoryRepository Categories { get; }
        PhotoImgRepository PhotoImgs { get; }
        ProductRepository Products { get; }
        void SaveChanges();
    }
}
