using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarket.Models
{
    public class Offer
    {
        public int OfferId { get; set; }
        public int OfferTypeId { get; set; }
        public string CategoryOn { get; set; }
        public string SubCategoryOn { get; set; }
        public string ProductOn { get; set; }
        public int discount { get; set; }
    }
}