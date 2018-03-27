using WebApp.Data;
using WebApp.Entities;

namespace WebApp.Repositories
{
    public class BrandRepository
        : GenericRepository<Brand>
    {
        public BrandRepository(EShoperDbContext Context) 
            : base(Context){}
    }
}
