using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperMarket.Models
{
    public class SubCategory
    {
        public SubCategory()
        {
            
        }
        [Key]
        public int SubCategoryId { get; set; }
        [Required]
        [MaxLength(50), MinLength(2)]
        public string SubCategoryName { get; set; }
        
        public int CategoryId { get; set; }
        public byte[] SubCategoryImage { get; set; }

        public virtual Category Categories { get; set; }
      
    }
}