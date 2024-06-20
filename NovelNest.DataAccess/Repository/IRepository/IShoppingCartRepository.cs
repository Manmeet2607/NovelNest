using NovelNest.Models;
using NovelNest.Models.Models;

namespace NovelNest.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {


        void Update(ShoppingCart obj);
    }
}
