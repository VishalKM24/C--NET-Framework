using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_DataLoader
{
    public class User
    {
        public string UserId { get; set; }
        public string Age { get; set; }
        public string City { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        List<BookUserRating> books { get; set; } = new List<BookUserRating>();

        public User(string userId, string age, string city, string state, string country)
        {
            UserId = userId;
            Age = age;
            City = city;
            this.state = state;
            this.country = country;
        }
    }
}
