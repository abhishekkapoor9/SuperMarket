using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SuperMarket.Models;
using SuperMarke.Models;

namespace SuperMarket.Models
{
    public partial class EComDBEntities : DbContext
    {
        public virtual DbSet<Attribute> attributes { get; set; }
        public virtual DbSet<Brand> brands { get; set; }
        public virtual DbSet<Customer> customers { get; set; }
        public virtual DbSet<CustomerOrder> customerorders { get; set; }
        public virtual DbSet<Login> logins { get; set; }
        public virtual DbSet<Offer> offers { get; set; }
        public virtual DbSet<OfferType> Order { get; set; }
        public virtual DbSet<Order> orders { get; set; }
        public virtual DbSet<Product> products { get; set; }
        public virtual DbSet<ProductAvailability> produtAvailabilitys { get; set; }
        public virtual DbSet<Rate> rates { get; set; }
        public virtual DbSet<SubCategory> subcategories { get; set; }
        public virtual DbSet<Supplier> suppliers { get; set; }


    }
    class Program
    {
   
        //create DBContext object
        using (var dbCtx = new EComDBEntities())
        {
            //Add Student object into Students DBset
            dbCtx.Students.Add(newStudent);

            // call SaveChanges method to save student into database
            dbCtx.SaveChanges();
        }
    
}
}

