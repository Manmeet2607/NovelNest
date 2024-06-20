
using NovelNest.DataAccess.Data;
using NovelNest.Models;
using NovelNest.Models.Models;
using NovelNest.Repository.IRepository;

namespace NovelNest.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {

        private ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(ApplicationUser obj)
        {
            _db.ApplicationUser.Update(obj);
        }
    }
}
