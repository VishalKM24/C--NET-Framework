using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TaxCalculatorFactory fac1 = TaxCalculatorFactory.Instance;
            //TaxCalculatorFactory fac2 = TaxCalculatorFactory.Instance;
            //Console.WriteLine($"factpry1 = {fac1.GetHashCode()}");
            //Console.WriteLine($"factpry2 = {fac2.GetHashCode()}");

            //TaxCalculatorFactory factory = new TaxCalculatorFactory();
            ITaxCalculator calc = TaxCalculatorFactory.Instance.CreateTaxCalculator();
            BillingSystem billingSystem = new BillingSystem(calc);
            Console.WriteLine(billingSystem.GenerateBill(5000));
        }
    }

    public class TaxCalculatorFactory
    {
        private TaxCalculatorFactory()
        {

        }

        public static readonly TaxCalculatorFactory Instance = new TaxCalculatorFactory();

        //public static TaxCalculatorFactory Instance = null;
        //public static TaxCalculatorFactory GetInstance()
        //{
        //    if (Instance == null)
        //        Instance = new TaxCalculatorFactory();
        //    return GetInstance();

        //}

        public virtual ITaxCalculator CreateTaxCalculator()
        {
            // ConfigurtionManager is used to get the data from app.config files
            string calculatorClassName =  ConfigurationManager.AppSettings["CALC"];

            // Reflextion
            Type theType = Type.GetType(calculatorClassName);
            
            return (ITaxCalculator)Activator.CreateInstance(theType);
        }
    }

    public class BillingSystem
    {
        ITaxCalculator calc = null;

        public BillingSystem(ITaxCalculator calc)
        {
            this.calc = calc;
        }

        public double GenerateBill(double amount)
        {
            return calc.CalculateTax(amount);
        }
    }

    public interface ITaxCalculator
    {
        double CalculateTax(double Amount);
    }
    public class KATaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double Amount)
        {
            int cst = 120;
            int kst = 140;
            int sbt = 50;
            int kkt = 10;

            double tax = cst + kst + sbt + kkt;
            Console.WriteLine("Using KA Tax Calculator");
            return tax;
        }
    }

    public class TNTaxCalculator: ITaxCalculator
    {
        public double CalculateTax(double Amount)
        {

            int cst = 120;
            int kst = 140;
            int sbt = 50;
            int kkt = 10;

            double tax = cst + kst + sbt + kkt;
            Console.WriteLine("Using TN Tax Calculator");
            return tax;
        }
    }

    public class USTaxCalculator
    {
        public long ComputeTax(long Amount)
        {
            Console.WriteLine("Using US Tax Calculator");
            return 234;
        }
    }

    public class USTaxCalculatorAdaptor : ITaxCalculator
    {
        public double CalculateTax(double Amount)
        {
            USTaxCalculator calc = new USTaxCalculator();
            long tax = calc.ComputeTax((long)Amount);
            
            return (double)tax;
        }
    }
}
