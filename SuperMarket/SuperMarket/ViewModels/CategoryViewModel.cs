using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SuperMarket.ViewModels
{
    public class CategoryViewModel
    {
        [DisplayName("Category Name:")]
        public string CategoryName { get; set; }
        [DisplayName("Sub-Category Name:")]
        public string SubCategoryName { get; set; }
        [DisplayName("Product Name:")]
        public string ProductName { get; set; }
        [DisplayName("Attribute Name:")]
        public string AttributeName { get; set; }
        [DisplayName("Attribute Values:")]
        public string AttributeValues { get; set; }
        [DisplayName("Brand Name:")]
        public string BrandName { get; set; }
        [DisplayName("Product Price:")]
        public int Price { get; set; }
        [DisplayName("Rate Name:")]
        public string RateName { get; set; }
        [DisplayName("Supplier Name:")]
        public string SupplierNmae { get; set; }
        [DisplayName("Producy Quantity:")]
        public int ProductQuantity { get; set; }
        [DisplayName("Rate Price:")]
        public int RatePrice { get; set; }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategory { get; set; }
        public int SupplierId { get; set; }
        public int BrandID { get; set; }
        public int AttributeId { get; set; }
        public int SubCategoryId { get; set; }
        public int RateId { get; set; }
    }
}