using System;

namespace Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();

            while (comand != "stop")
            {
                comand = Console.ReadLine();

                int currentNum = int.Parse(comand);

                if (currentNum < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

            }
        }
    }
}
