using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMarket.ViewModel
{
    public class ProductCategoryBrandVM
    {
        public string CategoryName { get; set; }
        public byte[] CatogaryImage { get; set; }
        public string SubCategoryName { get; set; }
        public byte[] SubCategoryImage { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public byte[] BrandImage { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public byte[] ProductImage { get; set; }
    }
}