
using NovelNest.DataAccess.Data;
using NovelNest.Models;
using NovelNest.Models.Models;
using NovelNest.Repository.IRepository;

namespace NovelNest.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
