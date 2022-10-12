using EFHandsOn1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFHandsOn1.UI;
using EFHandsOn1.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EFHandsOn1.UI
{
    public class PhoneRepository : IPhoneReository
    {
        private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            return conn;
        }
        public List<CustomerOrder> GetAllCustomerOrders()
        {
            PhoneDbContext db = new PhoneDbContext();
            List <CustomerOrder> ord = new List<CustomerOrder> ();

            //using (SqlConnection conn = GetConnection())
            //{
            //    string sqlGet = "select Orders from Customer";
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.Connection = conn;
            //    cmd.CommandText = sqlGet;
            //    cmd.ExecuteNonQuery();

            //    SqlDataReader reader = cmd.ExecuteReader();
            //    reader.Read();
            //}

            //var ctx;
            //using (SqlConnection conn = GetConnection())
            //{
            //    var studentList = conn.
            //                        .SqlQuery("Select * from Students")
            //                        .ToList<Student>();
            //}

            return (from p in db.CustomerOrders.Include("Customer") select p).ToList();
        }

        public List<CustomerOrder> GetCustomerOrders(long CustomerId)
        {
            PhoneDbContext db = new PhoneDbContext();
            // (from p in db.CustomerOrders.Include("Customer") where p.Customer.CustomerId == CustomerId select p).ToList();
            Customer cus = db.Customers.Find(CustomerId);
            db.SaveChanges(); //Optional as find doesn't make any changes in database
            return cus.Orders;
        }

        public long SaveCustomer(Customer customer)
        {
            PhoneDbContext db = new PhoneDbContext();
            db.Customers.Add(customer);
            Console.WriteLine("Customer Data Added...");
            return db.SaveChanges();
        }

        public long SaveOrder(CustomerOrder order)
        {
            PhoneDbContext db = new PhoneDbContext();
            db.CustomerOrders.Add(order);
            Console.WriteLine("Customer Order Data Saved...");
            return db.SaveChanges();
        }

        public long SaveOrderedPhone(OrderedPhone phone, long OrderId)
        {
            PhoneDbContext db = new PhoneDbContext();
            CustomerOrder order = db.CustomerOrders.Find(OrderId);
            order.OrderedPhones.Add(phone);

            Console.WriteLine("Saved Ordered Phone...");
            return db.SaveChanges();
        }

        public long SavePhone(Phone phone)
        {
            PhoneDbContext db = new PhoneDbContext();
            db.Phones.Add(phone);
            Console.WriteLine("Phone Data Aadded...");
            return db.SaveChanges();

        }


        
    }
}
