using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrelationEngine
{
    public class PearsonRecommender : IRecommender
    {
        List<int> lst1 = new List<int>();
        List<int> lst2 = new List<int>();
        List<int> lst3 = new List<int>();
        List<int> lst4 = new List<int>();
        List<int> lst5 = new List<int>();

        public double GetCorellation(int[] baseData, int[] otherData)
        {
            lst1 = baseData.ToList();
            lst2 = otherData.ToList();

            int size_1 = lst1.Count;
            int size_2 = lst2.Count;

            
            if(size_1 > size_2)
            {
                int size_3 = size_1 - size_2;
                while (size_3 > 0)
                {
                    lst2.Add(1);
                    lst1[size_1 - size_3]++;
                    size_3--;
                }
            }
            else if(size_2 > size_1)
            {
                int temp = size_2 - size_1;
                while(temp > 0)
                {
                    temp--;
                    lst2.RemoveAt(size_1);
                }
            }

            if (size_1 == size_2 )
            {
                for (int i = 0; i < size_1; i++)
                {
                    if (lst1[i] == 0 || lst2[i] == 0)
                    {
                        lst1[i]++;
                        lst2[i]++;
                    }
                }
            }


            for (int i = 0; i < size_1; i++)
            {
                lst3.Add(lst1[i] * lst2[i]);
                lst4.Add(lst1[i] * lst1[i]);
                lst5.Add(lst2[i] * lst2[i]);
            }

            int sum_xy = lst3.Sum();
            int sum_x = lst1.Sum();
            int sum_y = lst2.Sum();
            int sum_x2 = lst4.Sum();
            int sum_y2 = lst5.Sum();

            double num, deno, res;

            num = (size_1 * sum_xy) - (sum_x * sum_y);
            deno = ((size_1 * sum_x2) - (sum_x * sum_x)) * ((size_1 *sum_y2) - (sum_y * sum_y));
            deno = Math.Sqrt(deno);
            res = num / deno;

            Console.WriteLine($"Sum_xy: {sum_xy}");
            Console.WriteLine($"Sum_x: {sum_x}");
            Console.WriteLine($"Sum_y: {sum_y}");
            Console.WriteLine($"Sum_x2: {sum_x2}");
            Console.WriteLine($"Sum_y2: {sum_y2}");
            ////Console.WriteLine($);
            //Console.WriteLine($"Num: {num}");
            //Console.WriteLine($"Deno: {deno}");
            return res;
        }
 
    }
}
