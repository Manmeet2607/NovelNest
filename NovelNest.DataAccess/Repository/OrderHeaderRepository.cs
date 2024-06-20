
using NovelNest.DataAccess.Data;
using NovelNest.DataAccess.Repository.IRepository;
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
    public class OrderHeaderRepository : Repository<OrderHeader> , IOrderHeaderRepository
    {

        private ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db) : base(db) 
            {
                _db = db;
            }

       
        public void Update(OrderHeader obj)
        {
           _db.OrderHeaders.Update(obj);
        }



        public void updateStatus(int id, string orderStatus, string? payementStatus = null)
        {
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            if (orderFromDb != null)
            {
                orderFromDb.OrderStatus = orderStatus;
                if (!string.IsNullOrEmpty(payementStatus))
                {
                    orderFromDb.PaymentStatus = payementStatus;
                }
            }
        }

        public void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId)
        {
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);


            if (!string.IsNullOrEmpty(sessionId)) //session id is generated when a user tries to make a payment and when it is successful a paymentIntentId gets generated
            {
                orderFromDb.SessionId = sessionId;
            }
            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                orderFromDb.PaymentIntentId = paymentIntentId;
                orderFromDb.PaymentDate = DateTime.Now;
            }

        }
    }
    }
    
