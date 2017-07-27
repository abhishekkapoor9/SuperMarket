using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Models
{
    public class Product
    {
        public Product() 
        {
            this.Suppliers = new HashSet<Supplier>();
        }

        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int SubCategory { get; set; }
        public int SupplierId { get; set; }
        public int BrandID { get; set; }
        public int AttributeId { get; set; }
        public int SubCategoryId { get; set; }

        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}