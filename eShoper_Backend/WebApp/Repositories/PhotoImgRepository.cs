using WebApp.Data;
using WebApp.Entities;

namespace WebApp.Repositories
{
    public class PhotoImgRepository
        : GenericRepository<PhotoImage>
    {
        public PhotoImgRepository(EShoperDbContext Context) 
            : base(Context){}
    }
}
