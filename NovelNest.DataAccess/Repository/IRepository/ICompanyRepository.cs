using NovelNest.Models;
using NovelNest.Models.Models;

namespace NovelNest.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {


        void Update(Company obj);
    }
}
