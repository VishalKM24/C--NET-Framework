using AI_DataLoader;
using CorrelationEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateCorrelation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PearsonRecommender pr = new PearsonRecommender();


            //int[] baseA = new int[] { 20, 24, 17 };
            //int[] other = new int[] { 30, 20, 27, 12, 24 };

            //Console.WriteLine(pr.GetCorellation(baseA, other));

            CSVDataLoader test = new CSVDataLoader();
            test.Load();

        }
    }
}
