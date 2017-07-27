using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarket.Models
{
    public class OfferType
    {
        public int OfferTypeId { get; set; }
        public string OfferName { get; set; }
        public string OfferOn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}