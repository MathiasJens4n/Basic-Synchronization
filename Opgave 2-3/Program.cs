using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Opgave_2
{
    internal class Program
    {
        static readonly object locker = new object();
        static int total;
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Print);
            Thread t2 = new Thread(Print);

            t1.Start("*");
            t2.Start("#");
        }
        static void Print(object text)
        {
            while (true)
            {
                lock (locker)
                {
                    for (int i = 1; i <= 60; i++)
                    {
                        Console.Write(text.ToString());
                        if (i == 60)
                        {
                            total += i;
                        }
                    }
                    Console.Write($" {total}\n");

                    Thread.Sleep(1000);
                }
            }
        }
    }
}
