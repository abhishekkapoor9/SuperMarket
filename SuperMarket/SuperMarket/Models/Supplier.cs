using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Areas.Admin.Models
{
    public class Supplier
    {
        public Supplier()
        {
            this.Products = new HashSet<Product>();  
        }
        public int SupplierId { get; set; }
        public string SupplierNmae { get; set; }
        public string Addesee { get; set; }
        public string Description{ get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}