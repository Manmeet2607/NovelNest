
using Bulky.DataAccess.Repository.IRepository;
using NovelNest.DataAccess.Data;
using NovelNest.Models.Models;
using NovelNest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail> , IOrderDetailRepository
    {

        private ApplicationDbContext _db;
        public OrderDetailRepository(ApplicationDbContext db) : base(db) 
            {
                _db = db;
            }

       
        public void Update(OrderDetail obj)
        {
           _db.OrderDetails.Update(obj);
        }
    }
    }
