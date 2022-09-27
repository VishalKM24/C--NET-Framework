using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEp2
{
    delegate int HistogramSource();

    class Histogram
    {
        public event HistogramSource Hst = null;

        public void Draw()
        {
            if (Hst != null)
            {
                var invocationList = Hst.GetInvocationList();
                foreach (var invocation in invocationList)
                {
                    HistogramSource hs = (HistogramSource)invocation;
                    int num = hs();
                    for (int i = 0; i < num; i++)
                    {
                        Console.Write('*');
                    }
                    Console.WriteLine();

                }
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Histogram histogram = new Histogram();
            RandomSource rs = new RandomSource(5);
            RandomSource rs1 = new RandomSource(6);
            RandomSource rs2 = new RandomSource(7);
            histogram.Hst += rs.Magnitude;
            histogram.Hst += rs1.Magnitude;
            histogram.Hst += rs2.Magnitude;

            histogram.Draw();

        }
    }

    class RandomSource
    {
        private int max;
        private Random r;

        public RandomSource(int max)
        {
            this.max = max;
            r = new Random();
        }

        public int Magnitude()
        {
            return r.Next(max);
        }
    }

}
