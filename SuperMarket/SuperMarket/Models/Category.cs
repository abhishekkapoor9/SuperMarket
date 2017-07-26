using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperMarket.Areas.Admin.Models
{
    public class Category
    {
        public Category()
        {
            SubCategories = new List<SubCategory>();
        }
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public byte[] CatogaryImage { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
      
    }
}