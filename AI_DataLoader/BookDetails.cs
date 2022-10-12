using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_DataLoader
{
    public class BookDetails
    {
        public List<Book> books { get; set; } = new List<Book>();
        public List<BookUserRating> BookUserRatings { get; set; } = new List<BookUserRating>();
        public List<User> users { get; set; } = new List<User>();
        
    }
}
