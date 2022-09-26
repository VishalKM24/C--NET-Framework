using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    public class Calculator
    {
        private ICalculatorRepo repo = null;
        public Calculator(ICalculatorRepo repo)
        {
            this.repo = repo;
        }
        public Calculator()
        {
            repo = new CalculatorRepo();
        }

        public int Sum(int a, int b) 
        {
            if (a == 0 || b == 0)
                throw new System.Exception("Zero input provided");
            if(a<0 || b<0)
                throw new System.Exception();
            if (a % 2 != 0 || b % 2 != 0)
                throw new System.Exception("Odd input provided");

            int sum = a + b;

            string result = $"{a}+{b}={sum}";
            repo.Save(result);
            return sum;
        }
    }
}
