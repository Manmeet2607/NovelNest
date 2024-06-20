
using NovelNest.DataAccess.Data;
using NovelNest.Models;
using NovelNest.Models.Models;
using NovelNest.Repository.IRepository;
using System.Linq.Expressions;

namespace NovelNest.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {

        private ApplicationDbContext _db;
        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

       

        public void Update(ShoppingCart obj)
        {
            _db.shoppingCarts.Update(obj);
        }
    }
}
