using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MTDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine($"Main Running in thread {Thread.CurrentThread.ManagedThreadId}");
            // Console.WriteLine($"No of Cores in our Machine: {Environment.ProcessorCount}");
            Console.WriteLine("Running Sequentially");
            Stopwatch sw = Stopwatch.StartNew();
            M1();
            M2();
            M3("Vishal Mandal");
            Console.WriteLine(sw.ElapsedMilliseconds);
            

            Console.WriteLine("Running in Thread .....");
            sw.Restart();
            ThreadStart ts1 = new ThreadStart(M1);
            Thread t1 = new Thread(ts1);
            t1.Start();
            Thread t2 = new Thread(M2);
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine(sw.ElapsedMilliseconds);
            // ParameterizedThreadStart pts1 = new ParameterizedThreadStart(M3);

            Console.WriteLine("Running using TPL - Task");
            sw = Stopwatch.StartNew();
            Task tt1 = new Task(M1);
            tt1.Start();
            //Task tt2 = new Task(M2);
            //tt2.Start();
            Task tt2 = Task.Factory.StartNew(M2);
            
            tt1.Wait();
            tt2.Wait();
            Console.WriteLine(sw.ElapsedMilliseconds);

            Console.WriteLine("Running using TPL - Parallel");
            sw.Restart();
            Parallel.Invoke(M1, M2);
            Console.WriteLine(sw.ElapsedMilliseconds);

            Console.WriteLine("Running using TPL - Parallel For ...");
            sw.Restart();
            Parallel.Invoke(M11, M22);
            Console.WriteLine(sw.ElapsedMilliseconds);

        }
        static void M1()
        {
            
            Console.WriteLine($"M1 Running in thread {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
            }
        }

        static void M2()
        {
            Console.WriteLine($"M2  Running in thread {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
            }
        }
        static void M3(String str)
        {
            Console.WriteLine($"M3 Running in thread {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hii {str}");
        }
        static void M11()
        {

            Console.WriteLine($"M1 Running in thread {Thread.CurrentThread.ManagedThreadId}");
            //for (int i = 0; i < 10; i++)
            Parallel.For(1, 11, i => { Thread.Sleep(100); });
        }

        static void M22()
        {
            Console.WriteLine($"M2  Running in thread {Thread.CurrentThread.ManagedThreadId}");
            //for (int i = 0; i < 10; i++)
            Parallel.For(1, 11, i => { Thread.Sleep(100); });
        }

        static void F1() { }
        static void F2(int a) { }
        static int F3() { return 1; }
        static int F4(int a) { return a; }

        static void RunInThreads()
        {
            Thread t1 = new Thread(F1);
            t1.Start();

            Task tt1 = new Task(F1);
            tt1.Start();

            Thread t2 = new Thread( () => { F2(10); } );
            t2.Start();

            Task tt2 = new Task(() => { F2(10); });
            tt2.Start();

            // If function returns any value, go for Generic 

            Task<int> tt3 = new Task<int>(F3);
            tt3.Start();
            // Do much stuffs as result might not be generated
            // if you call for result, it will wait until it returns
            // instead no use of multithreading

            int r = tt3.Result;
            //

            Task<int> tt4 = new Task<int>(() => { return F4(100); });
            tt4.Start();
            //
            //
            //
            int res = tt4.Result;

        }

    }
}
