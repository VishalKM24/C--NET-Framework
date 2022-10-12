using EFHandsOn1.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFHandsOn1.Data
{
    public  class PhoneDbContext: DbContext
    {
        // 1. Configure the Database
        public PhoneDbContext() : base("name=default")
        {

        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<OrderedPhone> OrderedPhones { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
    }
}
