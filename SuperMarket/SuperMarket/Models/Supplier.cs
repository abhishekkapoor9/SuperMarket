using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Models
{
    public class Supplier
    {
        public Supplier()
        {
            this.Products = new HashSet<Product>();  
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SupplierId { get; set; }
        [Required]
        public string SupplierNmae { get; set; }
        public string Address { get; set; }
        public string Description{ get; set; }
        public string mobileNumber { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}