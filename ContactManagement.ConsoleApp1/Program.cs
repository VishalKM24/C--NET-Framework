using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContactDbContext db = new ContactDbContext();
            db.Database.Log = Console.WriteLine;


        }
    }
}
