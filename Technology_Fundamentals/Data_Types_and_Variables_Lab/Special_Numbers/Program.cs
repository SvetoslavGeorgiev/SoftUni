using System;
using System.Diagnostics;
using System.Numerics;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            long sum = 0;
            Stopwatch sw = Stopwatch.StartNew();


            for (long i = 1; i < 100000000; i++)
            {
                sum += i;
            }
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine(sum);
        }
    }
}
