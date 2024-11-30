using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MultiThreading
{
    public class SynchronizationDemo1
    {
        public void M1()
        {
            Monitor.Enter(this);
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine(Thread.CurrentThread.Name);
                    Console.WriteLine(i);
                    // Thread.Sleep(2000);
                }

            }
            Monitor.Pulse(this);
            Monitor.Exit(this);

        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            SynchronizationDemo1 test = new SynchronizationDemo1();

            Thread t1 = new Thread(new ThreadStart(test.M1));

            Thread t2 = new Thread(new ThreadStart(test.M1));
            t1.Name = "T1";
            t2.Name = "T2";
            t1.Start();
            t2.Start();


        }
    }


}

