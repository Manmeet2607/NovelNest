using NovelNest.Models;
using NovelNest.Models.Models;

namespace NovelNest.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {


        void Update(Category obj);
    }
}
