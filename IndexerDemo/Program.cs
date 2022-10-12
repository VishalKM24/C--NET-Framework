using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rainbow rainbow = new Rainbow();
            Console.WriteLine(rainbow.GetColor(3));
            Console.WriteLine(rainbow["4rwere"]);

            //for (int i = 0; i < ; i++)
            //{
            //    Console.WriteLine(rainbow.GetColor(i));
            //} 
            
            

        }
    }

    class Rainbow
    {
        private string[] colors = { "Violet", "Indigo", "Blue", "Green", "Yellow", "Organge", "Red" };

        public string GetColor(int i)
        {
            return colors[i];
        }
        public string this[int i]
        {
            get { return colors[i]; }
        }

        public string this[string str]
        {
            get { return str; }
        }
    }
}
