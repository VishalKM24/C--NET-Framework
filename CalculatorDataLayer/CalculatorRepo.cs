using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    public class CalculatorRepo: ICalculatorRepo
    {
        public bool Save(string input)
        {
            StreamWriter sw = new StreamWriter("d:\\calculator.txt", true);
            sw.WriteLine(input);
            sw.Close();
            return true;
        }
    }
}
