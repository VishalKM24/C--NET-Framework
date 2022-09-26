using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLoop
{
    public class SimpleLoopTest
    {

        private int[] numbers = { 5, -77, 8, -11, 4, 1, -20, 6, 2, 10 };

        public int FindSum(int numItems)
        {
            int total = 0;
            if (numItems <= 10)
            {
                for (int count = 0; count < numItems; count = count + 1)
                {
                    if (numbers[count] > 0)
                    {
                        total = total + numbers[count];
                    }
                }
            }
            return total;
        }
    }

}
