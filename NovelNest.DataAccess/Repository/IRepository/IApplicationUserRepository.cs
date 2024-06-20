using NovelNest.Models;
using NovelNest.Models.Models;

namespace NovelNest.Repository.IRepository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {


        void Update(ApplicationUser obj);
    }
}
