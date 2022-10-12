using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_DataLoader
{
    public  class BookUserRating
    {
        public string Rating { get; set; }
        public string ISBN { get; set; }
        public string UserID { get; set; }

        public BookUserRating(string rating, string iSBN, string userID)
        {
            Rating = rating;
            ISBN = iSBN;
            UserID = userID;
        }
    }
}
