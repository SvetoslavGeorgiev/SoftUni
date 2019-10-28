using System;

namespace Passed
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Title ="My App v1.0";

            double grade = double.Parse(Console.ReadLine());

            if (grade >= 3.00)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}
