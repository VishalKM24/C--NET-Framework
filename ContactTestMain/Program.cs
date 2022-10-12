using ContactsManagementsApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContactTestMain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contact c = new Contact { Name = "Vishal" , Email = "vkmandal26@gmail.com", Mobile = "9265112354", location = "Bangalore"};
            IContactsRepo repo = new ContactdbRepo();
            Contact c1 = new Contact { Name = "Mandal", Email = "vkmandal268@gmail.com", Mobile = "9265112354", location = "Vadodara" };

            repo.Save(c);
            repo.Save(c1);
            //repo.Delete(2);

            Contact c2 = new Contact { Name = "Aditya", Email = "lpnaga@gmail.com", Mobile = "9265112354", location = "Bangalore" };
            //repo.Edit(2, c2);

            //repo.getContactById(1);



            Console.WriteLine("Contact Saved");

        }
    }
}
