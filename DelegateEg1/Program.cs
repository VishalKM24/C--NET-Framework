using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEg1
{
    delegate void MessageHandler(string str);
    internal class Program
    {
        static void Main(string[] args)
        {
           Publisher publisher = new Publisher();
           Subscriber subscriber = new Subscriber();
            publisher.msg += subscriber.CallMe;
            publisher.msg += subscriber.MeToo;
            publisher.msg += Subscriber.AndMe;
            //publisher.Dispatch("Hello"); // Manuallly calling Methods without class

            publisher.PublishDispatch("Hello Ayush");
        }
    }

    class Publisher
    {
        public event MessageHandler msg = null;
        public void Dispatch(string msg1)
        {
            if (msg != null)
                msg(msg1);
        }

        public void PublishDispatch(string msg1)
        {
            foreach (MessageHandler unicastDelegate in msg.GetInvocationList())
            {
                //unicastDelegate.DynamicInvoke(msg1); // Dynamic calling of function

                MessageHandler m = unicastDelegate as MessageHandler; // told to use downcasting
                m(msg1); 

                //Console.WriteLine(unicastDelegate);
            }
        }
    }
    class Subscriber
    {
        public void CallMe(string msg)
        {
            Console.WriteLine($"CallMe: {msg}");
        }
        public void MeToo(string msg)
        {
            Console.WriteLine($"MeToo: {msg}");
        }
        public static void AndMe(string msg)
        {
            Console.WriteLine($"AndMe: {msg}");
        }
    }
}
