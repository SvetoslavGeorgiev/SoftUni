using System;

namespace _09_Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());

            int currentYield = startingYield;

            int totalYield = 0;

            int daysCounter = 0;

            if (currentYield < 100)
            {
                Console.WriteLine(daysCounter);
                Console.WriteLine(totalYield);
            }
            else
            {
                while (currentYield >= 100)
                {
                    int extract = currentYield - 26;

                    totalYield += extract;
                    daysCounter++;

                    currentYield -= 10;
                }
                Console.WriteLine(daysCounter);
                Console.WriteLine(totalYield - 26);
            }
        }
    }
}
