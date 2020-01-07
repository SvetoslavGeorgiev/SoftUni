using System;
using System.Diagnostics;

namespace Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();

            int peopleInBus = int.Parse(Console.ReadLine());
            int busStops = int.Parse(Console.ReadLine());

            for (int i = 1; i <= busStops; i++)
            {
                int up = int.Parse(Console.ReadLine());
                peopleInBus -= up;
                int down = int.Parse(Console.ReadLine());
                peopleInBus += down;
                if (i % 2 == 0)
                {
                    peopleInBus -= 2;
                }
                else
                {
                    peopleInBus += 2;
                }
            }
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine($"The final number of passengers is : {peopleInBus}");
        }
    }
}
