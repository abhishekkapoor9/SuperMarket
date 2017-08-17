using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarket.Models
{
    public class ProductAvailability
    {
        public int ProductAvailabilityId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public int Price { get; set; }
        public int ProductAvailable { get; set; }
        public string ProductValues { get; set; }
        public int ProductRateid { get; set; }
        public string ProductRateValue { get; set; }
    }
}