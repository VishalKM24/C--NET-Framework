using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo2
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Account acc1 = new Account();
            acc1.alert += Notification.SendEmail;
            acc1.alert += Notification.SendSMS;
            acc1.alert += Notification.SendWhatsApp;
            // acc1.Subscribe(Notification.SendEmail); cannot be done
            
            Console.WriteLine($"Balance: {acc1.Balance}");
            acc1.Deposit(50000);
            Console.WriteLine($"\nAfter Deposit: \nBalance: {acc1.Balance}");
            acc1.alert -= Notification.SendSMS;
            acc1.Withdraw(10000);
            Console.WriteLine($"\nAfter Withdrawal \nBalance: {acc1.Balance}");
        }
    }
    public delegate void Alert(string msg);

    class Account
    {
        public int  Balance { get; private set; }
        public event Alert alert = null; // new Alert.Notofication(

        //public void Subscribe(Alert alert)
        //{
        //    this.alert += alert;
        //}
        //public void UnSubscribe(Alert alert)
        //{
        //    this.alert -= alert;
        //}
        // if alert is a private variable

        public void Deposit(int amount)
        {
            Balance += amount;
            // send email
            //Notification.SendEmail($"Deposited {amount}");
            if (alert != null)
                alert($"Deposited {amount}");
        }
        public void Withdraw(int amount)
        {
            Balance -= amount;
            // send email
            //Notification.SendEmail($"Withdrawn {amount}");
            if (alert != null)
                alert($"Withdrawn {amount}");

        }
    }
    public class Notification
    {
        public static void SendEmail(string str)
        {
            Console.WriteLine($"Mail: {str}");
        }

        public static void SendSMS(string str)
        {
            Console.WriteLine($"SMS: {str}");
        }
        public static void SendWhatsApp(string str)
        {
            Console.WriteLine($"SMS: {str}");
        }
    }
}
