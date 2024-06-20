using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelNest.Utility
{
    public class SD
    {
        public const string Role_Customer = "Customer";
        public const string Role_Company = "Company";  //belongs to a company and gets 30 days to a make a payment
        public const string Role_Admin = "Admin";   //can perform the complete CRUD
        public const string Role_Employee = "Employee";  //can perform only certain operations

        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusInProcess = "Processing";
        public const string StatusShipped = "Shipped";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";

        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusDelayedPayment = "ApprovedForDelayedPayment";
        public const string PaymentStatusRejected = "Rejected";
    }
}
