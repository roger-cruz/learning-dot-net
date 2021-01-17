using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsAndContextSwitching
{
    class Program
    {

        static void Main(string[] args)
        {
            Thread threadA = new Thread(ThreadA);
            Console.WriteLine("About to start Thread A");

            // You can give a name to the new and main thread.
            Thread.CurrentThread.Name = "Main Learning Thread";
            threadA.Name = "Thread A Worker";

            // This schedules execution of the thread method.
            threadA.Start();
            Console.WriteLine("Thread A started");
            while (true)
            {
                Thread.Sleep(2000);
                Console.Write("M");

            }
        }

        private static void ThreadA()
        {
                    Console.WriteLine("Thread A has been spawned");
                    while (true)
                    {
                        Thread.Sleep(2000);
                        Console.Write("A");
                    }
         }
    }
}
