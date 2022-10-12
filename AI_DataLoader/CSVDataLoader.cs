using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_DataLoader
{
    public class CSVDataLoader : IDataLoader
    {
        
        public BookDetails Load()
        {
            BookDetails bookdetails = new BookDetails();

            using (var reader = new StreamReader(@"C:\Users\Admin\Desktop\Framework-Projects\Sum\AI_DataLoader\BX-Books.csv"))
            {
                

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    
                    var values = line.Split(';');

                    Book book = new Book(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]);

                    bookdetails.books.Add(book);

                }
            }
            using (var reader = new StreamReader(@"C:\Users\Admin\Desktop\Framework-Projects\Sum\AI_DataLoader\BX-Users.csv"))
            {


                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var values = line.Split(';');

                    var location = values[2].Split(',');
                    User user; 
                    if (location.Length == 3)
                        user = new User(values[0], values[1], location[0], location[1], location[2]);


                    bookdetails.users.Add(user);

                }
            }
            using (var reader = new StreamReader(@"C:\Users\Admin\Desktop\Framework-Projects\Sum\AI_DataLoader\BX-Book-Ratings.csv"))
            {


                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var values = line.Split(';');

                    BookUserRating bookuserrating = new BookUserRating(values[0], values[1], values[2]);

                    bookdetails.BookUserRatings.Add(bookuserrating);

                }
            }


            return bookdetails;
        }
    }
}
