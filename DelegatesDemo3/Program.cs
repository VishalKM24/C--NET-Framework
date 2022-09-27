using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Client 1
            //ProcessManager.ShowProcessList();
            ProcessManager.ShowProcessList(FilterByNone);

            //Client 2 - show all process with starting character S
            //ProcessManager.ShowProcessList("S");

            FilterDelegate filter = new FilterDelegate(FilterByName); // using Delegate
            ProcessManager.ShowProcessList(filter);

            //Client 3 - All the process more than 50MB
            //ProcessManager.ShowProcessList(50*1024*1024);

            ProcessManager.ShowProcessList(FilterBySize); // using delegate

            // Anonymous Delegates
            ProcessManager.ShowProcessList(delegate(Process p)
                {
                    return p.WorkingSet64 >= 50 * 1024 * 1024;
                });


            // Lamda - Light weight syntax for Anonymous Delegates
            // Statement based lamda
            ProcessManager.ShowProcessList( (Process p) =>
            {
                return p.WorkingSet64 >= 50 * 1024 * 1024;
            });

            // expression based lamda function
            ProcessManager.ShowProcessList((Process p) => p.WorkingSet64 >= 50 * 1024 * 1024);

            // Light weight based expression based on lamda function
            ProcessManager.ShowProcessList( p => p.WorkingSet64 >= 50 * 1024 * 1024);

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var sum = numbers.Sum();

            var sum1 = numbers.Where(EvenNo).Sum();
            var sum2 = numbers.Where(n => n % 2 == 0).Sum();

            Console.WriteLine($"Sum: {sum} \nSum1: {sum1} \nSum2: {sum2}");


        }

        static bool EvenNo(int n)
        {
            return n % 2 == 0;
        }

        static bool FilterByNone(Process p)
        {
            return true;
        }

        // Client 2 - by name
        static bool FilterByName(Process p)
        {
            if (p.ProcessName.StartsWith("S"))
                return true;
            else
                return false;
        }

        // Client 3 - by size
        static bool FilterBySize(Process p)
        {
            return p.WorkingSet64 >= 50 * 1024 * 1024;
        }
    }

    // declare the delegate

    public delegate bool FilterDelegate(Process p);

    class ProcessManager
    {
        //public static void ShowProcessList()
        //{
        //    foreach (var p in Process.GetProcesses())
        //    {
        //        Console.WriteLine(p.ProcessName);
        //    }
        //}

        //public static void ShowProcessList(string sw)
        //{
        //    foreach (var p in Process.GetProcesses())
        //    {
        //        if(p.ProcessName.StartsWith(sw))
        //            Console.WriteLine(p.ProcessName);
        //    }
        //}

        //public static void ShowProcessList(long size)
        //{
        //    foreach (var p in Process.GetProcesses())
        //    {
        //        if(p.ProcessName.)
        //        Console.WriteLine(p.ProcessName);
        //    }
        //}


        public static void ShowProcessList(FilterDelegate filter)
        {
            foreach (var p in Process.GetProcesses())
            {
                if (filter(p))
                    Console.WriteLine(p.ProcessName);
            }
        }
    }
}
