using System;
using System.Threading;

namespace SingletonTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Thread t1 = Thread.CurrentThread;
            t1.Name = "Thread 1";

            ////////////////////////////////////////////////////
            
            Thread t2 = new Thread( () => Upper());
            Thread t3 = new Thread( () => Lower());

            t2.Start();
            t3.Start();

            void Upper()
            {
                for (int i = 0; i < 10; i++)
                {                    
                    Console.WriteLine("Thread 2 : " + SingletonTest.GetInstance.Number++);
                    Thread.Sleep(1000);
                }
            }

            void Lower()
            {
                for (int i = 0; i < 10; i++)
                {                    
                    Console.WriteLine("Thread 3 : " + SingletonTest.GetInstance.Number++);
                    Thread.Sleep(1300);
                }
            }

            Console.WriteLine(t1.Name + " Begin..");
            SingletonTest.GetInstance.Dispose();
            Console.WriteLine("Disposed");

        }
    }
}
