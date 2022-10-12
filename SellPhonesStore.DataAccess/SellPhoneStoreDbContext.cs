using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhonesStore.DataAccess
{
    public class SellPhoneStoreDbContext: DbContext
    {
    }

    public DbSet<Phone> Phones { get; set; }
}
