using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarket.Models
{
    public class Customer
    {
        public Customer()
        {
            //Orders = new List<Order>();
            CustomerOrders = new List<CustomerOrder>();
        }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Pincode { get; set; }
        public string Email { get; set; }
        public int Mobile { get; set; }
        public byte[] CustomerPhoto { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}