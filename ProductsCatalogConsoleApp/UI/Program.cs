using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace ProductsCatalogConsoleApp
{
    internal class Program
    {

        //class NamePrice
        //{
        //    public string PName { get; set; }
        //    public int Price { get; set; }
        //}


        static void Main(string[] args)
        {
            // Add new products - only OO
            // (localdb)\mssqllocaldb

            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;

            var p = db.Products.Find(1);
            p.Price = 50000;
            db.SaveChanges();

            // Generate store procedure for individual update
            // for bulk update use
            // 

            // SqlParameter p1 = new SqlParameter("@CategoryId", 3);
            db.Database.ExecuteSqlCommand("Catagory_delete @CategoryId", 3);



        }

        public static void SqlDirectExe()
        {

        }

        public static void SqlDirect()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;

            var allProducts = db.Products.ToList();
            //foreach (var item in allProducts)
            //{
            //    item.Price += 500;
            //}

            //db.SaveChanges();
            //Console.WriteLine("Updated..");
        }

        public static void SelectCustomers()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;

            var customers = db.People.OfType<Customer>().ToList();

            foreach (var item in customers)
            {
                Console.WriteLine(item.PersonId  + "\t" + item.Name);
            }
        }

        public static void AdddCustomerAndSupplier()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;

            Address a = new Address();
            Customer c = new Customer { Name = "Customer 1", Discount = 1, Type = "Bronze" };
            Supplier s = new Supplier { Name = "Supplier 1", GST = "adkjslnc", Rating = 9 };

            db.People.Add(c);
            db.People.Add(s);
            c.Address = a;
            s.Address = a;

            db.SaveChanges();
            Console.WriteLine("Saved...");
        }

        public static void EagerLoading()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;

            //var plist = from p in db.Products
            //            select p;

            //// var plist = from p in db.Products select p.Name;
            //// Can be used to get the single column data

            //var plist1 = from p in db.Products
            //             select new
            //             { PName = p.Name, CName = p.TheCatagory.Name };

            //foreach (var item in plist)
            //{
            //    Console.WriteLine($"{item.Name}");
            //    Console.WriteLine(item.TheCatagory.Name);
            //}

            //MARS in Entity Framework
        }

        public static void UpdateProductWithCat()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;

            var cat = db.Catagories.Find(2);
            var p = db.Products.Find(5);
            p.TheCatagory = cat;
            db.SaveChanges();
        }

        public static void ProductWithExistingCategory()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;

            // Add new Prodcust with existing Category
            var existingCat = db.Catagories.Find(1);
            var mobile = (from c in db.Catagories
                          where c.Name == "Mobiles" select c).FirstOrDefault();

            var p = new Product { Name = "Galaxy Z Fold", Brand = "Samsung", Price = 78000, InStock = true, TheCatagory = mobile };
            db.Products.Add(p);
            db.SaveChanges();
        }

        public static void SaveProductAndCategory()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;
 

            var cat = new Catagory { Name = "Mobiles", Description = "Smart Phone" };
            var p = new Product { Name = "Iphone 13 pro max", Price = 75000, Brand = "Apple", InStock = true, TheCatagory = cat };

            db.Products.Add(p);
            db.SaveChanges();

        }

        public static void LinQ()
        {
            //LINQ to Entities
            // SQL Select : select * from products where proce >= 10000

            ProductsDbContext db = new ProductsDbContext();
            var costlyProducts = from p in db.Products where p.Price >= 10000 select p;

            var cplist = db.Products.Where(p => p.Price >= 10000);

            foreach (var item in costlyProducts)
            {
                Console.WriteLine($"{item.Name}\t{item.Price}");
            }

            //To find the costliest product
            var costliestProduct = (from p in db.Products orderby p.Price descending select p).FirstOrDefault();
            Console.WriteLine(costliestProduct.Name);

            int maxPrice = (from p in db.Products select p.Price ).Max();
            var costliestProduct1 = from p in db.Products 
                                    where p.Price == maxPrice 
                                    select p;

            var result = from p in db.Products 
                         where p.Price == (from i in db.Products select p.Price).Max() 
                         select p;

            //Lamda function in LINQ

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var evenNumbers = from n in numbers where n % 2 == 0 select n;


        }

        public static void Edit()
        {
            ProductsDbContext db = new ProductsDbContext();
            var ProductToEdit = db.Products.Find(2);
            if(ProductToEdit != null)
            {
                ProductToEdit.Price += 500;
                db.SaveChanges();
                Console.WriteLine("The data Edited");
            }
            else
                Console.WriteLine("The data not found");
        }

        public static void Remove()
        {
            ProductsDbContext db = new ProductsDbContext();
            var productToDel = db.Products.Find(1);
            if(productToDel != null)
            {
                db.Products.Remove(productToDel);
                db.SaveChanges();
                Console.WriteLine("Deleted");
            }
            else
                Console.WriteLine("Data not present");
        }

        public static void Get()
        {
            ProductsDbContext db = new ProductsDbContext();
            var p = db.Products.Find(1);

            var pp = db.Products.Find(1);

            if (p == null)
            {
                Console.WriteLine("Product not found");
            }
            else
            {
                Console.WriteLine(p.Name + "\t" + p.Price);
            }
        }

        public static void Save()
        {
            Product p = new Product { Name = "Samsung Note 10", Price = 80000 };
            ProductsDbContext db = new ProductsDbContext();
            db.Products.Add(p);
            db.SaveChanges();

            Console.WriteLine("Saved");
        }
    }
}
