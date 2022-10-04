using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIODemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data = "But Ankit loves Palak Goel";
            StreamWriter sw = new StreamWriter("C:\\Users\\Admin\\Desktop\\Framework-Projects\\Sum\\FileIODemo1\\text1.txt", true);
            sw.WriteLine(data);
            sw.Close();
            ReadAll();
        }

        private static void ReadAll()
        {
            StreamReader sw = new StreamReader("C:\\Users\\Admin\\Desktop\\Framework-Projects\\Sum\\FileIODemo1\\text1.txt", true);
            try
            {
                string allData = sw.ReadToEnd();
                Console.WriteLine(allData);
            }
            catch
            {
                Console.WriteLine();
            }
        }
    }
}
