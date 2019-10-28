using System;

namespace Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = 1;
            while (number < 101)
            {
                if (number % 3 == 0)
                {
                    Console.WriteLine(number);
                }  
                number++;
            }
        }
    }
}
