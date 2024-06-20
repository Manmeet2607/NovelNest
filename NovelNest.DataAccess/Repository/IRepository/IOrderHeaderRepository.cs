
using NovelNest.Models.Models;
using NovelNest.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelNest.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {

      
        void Update(OrderHeader obj);//update typically updated the complete order header but if based on ID we only want to update the order status or payment status so for that scenario we create update status
        void updateStatus(int id,string orderStatus,string? payementStatus=null);//order status(it is required always tend to change at every state howvere payment status may remain as it is after it has been approved

        void UpdateStripePaymentId(int id,string sessionId,string paymentIntentId);
    }
}
