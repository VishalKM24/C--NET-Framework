using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionExe
{
    internal class ExceptionTest
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9};

            try
            {
                for(int i = 0; i < 11; i++)
                {
                    Console.WriteLine($"{arr[i]}");
                }
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.ToString());
                Debug.WriteLine(ex.InnerException.ToString());
            }
        }
    }
}
