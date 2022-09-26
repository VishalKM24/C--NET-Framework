using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleLoop.SimpleLoopTest s=new SimpleLoop.SimpleLoopTest();
            Console.WriteLine(s.FindSum(10));
        }
    }
}
