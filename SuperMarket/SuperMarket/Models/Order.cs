using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarket.Models
{
    public class Order
    {
        public Order()
        {

        }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProducrId { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime OrdereDate { get; set; }
        public string deliveryAddress { get; set; }

        public virtual Customer Customers { get; set; }
    }
}