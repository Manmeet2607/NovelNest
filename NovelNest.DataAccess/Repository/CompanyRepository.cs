
using NovelNest.DataAccess.Data;
using NovelNest.Models;
using NovelNest.Models.Models;
using NovelNest.Repository.IRepository;

namespace NovelNest.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {

        private ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        

        public void Update(Company obj)
        {
            _db.Companies.Update(obj);

        }
    }
}
