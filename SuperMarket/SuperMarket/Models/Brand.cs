using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarket.Areas.Admin.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public byte[] BrandImage { get; set; }
    }
}