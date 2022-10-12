using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_DataLoader
{
    public class Book
    {
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public string YearOfPublication { get; set; }
        public string ImagerUrlSmall { get; set; }
        public string ImageUrlMedium { get; set; }
        public string ImageUrlLarge { get; set; }

        List<BookUserRating> userRatings { get; set; } = new List<BookUserRating>();

        public Book(string iSBN, string bookTitle, string bookAuthor, string yearOfPublication, string publisher, string imagerUrlSmall, string imageUrlMedium, string imageUrlLarge)
        {
            ISBN = iSBN;
            BookTitle = bookTitle;
            BookAuthor = bookAuthor;
            YearOfPublication = yearOfPublication;
            Publisher = publisher;
            ImagerUrlSmall = imagerUrlSmall;
            ImageUrlMedium = imageUrlMedium;
            ImageUrlLarge = imageUrlLarge;
            
        }
    }
}
