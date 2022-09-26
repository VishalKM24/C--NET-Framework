using CalculatorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fno;
            int sno;
            int sum = 0;
            Console.Write("Enter First Number: ");
            fno = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            sno = int.Parse(Console.ReadLine());
            Calculator calc = new Calculator();
            sum = calc.Sum(fno, sno);

            Console.WriteLine($"The sum of {fno} and {sno} is {sum}");
        }
    }
}
