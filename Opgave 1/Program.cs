using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Synkronosering_Øvelser
{
    internal class Program
    {
        static readonly object locker = new object();
        static int count;
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Counter);
            Thread t2 = new Thread(Counter);


            t1.Start(2);
            t2.Start(-1);

            Console.ReadKey();
        }
        static void Counter(object num)
        {
            while (true)
            {
                Monitor.Enter(locker);

                try
                {
                    count += Convert.ToInt32(num);

                    Thread.Sleep(1000);

                    Console.WriteLine(count);

                }
                finally
                {
                    Monitor.Exit(locker);
                }
            }
        }
    }
}
