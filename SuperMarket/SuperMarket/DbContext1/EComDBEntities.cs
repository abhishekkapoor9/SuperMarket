﻿using System.Data.Entity;
using SuperMarket.Models;
using System;
using System.Data;
using SuperMarket;
namespace SuperMarket.Models
{
    public class EComsDBEntity : DbContext
    {
        public EComsDBEntity(): base("EfqresDbContext")
            {
            }

        public virtual DbSet<Attribute> attributes { get; set; }
        public virtual DbSet<Category> categories { get; set; }
        public virtual DbSet<Brand> brands { get; set; }
        public virtual DbSet<Customer> customers { get; set; }
        public virtual DbSet<CustomerOrder> customerorders { get; set; }
        public virtual DbSet<Login> logins { get; set; }
        public virtual DbSet<Offer> offers { get; set; }
        public virtual DbSet<OfferType> Offertypes { get; set; }
        public virtual DbSet<Order> orders { get; set; }
        public virtual DbSet<Product> products { get; set; }
        public virtual DbSet<ProductAvailability> produtAvailabilities { get; set; }
        public virtual DbSet<Rate> rates { get; set; }
        public virtual DbSet<SubCategory> subcategories { get; set; }
        public virtual DbSet<Supplier> suppliers { get; set; }

    }
    
}

