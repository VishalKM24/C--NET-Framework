using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalogConsoleApp
{
    public class ProductsDbContext: DbContext
    {
        //1. Configure the Database
        public ProductsDbContext() : base("name = default")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Create and mao to sp

            // Individual Entity for Stored Procedures
            // modelBuilder.Entity<Product>().MapToStoredProcedures();

            // All table entity generator
            modelBuilder.Types().Configure(t => t.MapToStoredProcedures());

            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().Map(c =>
            c.MapInheritedProperties()).ToTable("Customer");

            modelBuilder.Entity<Supplier>().Map(c => 
            c.MapInheritedProperties()).ToTable("Supplier");
        }

        //2. Configure the tables

        public DbSet<Product> Products { get; set; }

        public DbSet<Catagory> Catagories { get; set; }
        
        // public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Person> People { get; set; }
        //public DbSet<Customer> Customers { get; set; }
    }
}
