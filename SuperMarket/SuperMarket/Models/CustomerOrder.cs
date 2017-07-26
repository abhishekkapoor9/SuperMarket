using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarket.Models
{
    public class CustomerOrder
    {
        public CustomerOrder()
        {

        }

        public int CustomerOrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Orderdate { get; set; }

        public virtual Customer Customers { get; set; }
    }
}