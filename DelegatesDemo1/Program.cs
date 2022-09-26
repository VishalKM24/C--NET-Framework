using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo1
{
    // delegate is a special class and cannot be used as an simple abstraction class
    //Step 1 : 
    delegate void MyDelegate(string str); // need to define type and parameter, can only hold single address



    internal class Program
    {
        static void Main(string[] args)
        {
            // direct
            //Program.Greetings("Hello");

            //indirect
            //Step 2 : Instantiate and initialize
            Program p = new Program();
            MyDelegate delObj = new MyDelegate(p.Hello);
            delObj += Greetings; // Overwrites the method
            delObj -= p.Hello;

            //Step 3 : Delegates Invoke/calling
            //delObj.Invoke("Hello");
            delObj("Vishal Mandal");
        }

        public static void Greetings(string msg)
        {
            Console.WriteLine($"Greetings: {msg}");
        }

        public void Hello(string name)
        {
            Console.WriteLine($"Hello: {name}");
        }
    }

}
