using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ContactManagement.ConsoleApp1
{
    public partial class ContactDbContext : DbContext
    {
        public ContactDbContext()
            : base("name=ContextDbContext")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Contact>()
                .Property(e => e.email)
                .IsFixedLength();

            modelBuilder.Entity<Contact>()
                .Property(e => e.mobile)
                .IsFixedLength();

            modelBuilder.Entity<Contact>()
                .Property(e => e.location)
                .IsFixedLength();
        }
    }
}
