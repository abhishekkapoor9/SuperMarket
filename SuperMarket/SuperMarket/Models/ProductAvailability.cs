using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarket.Areas.Admin.Models
{
    public class ProductAvailability
    {
        public int ProductAvailabilityId { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }
        public int ProductAvailable { get; set; }
    }
}