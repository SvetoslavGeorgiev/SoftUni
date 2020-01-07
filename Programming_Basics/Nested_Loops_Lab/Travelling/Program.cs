using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            while (destination != "End")
            {
                double neededMoney = double.Parse(Console.ReadLine());
                double savedMoney = 0;
                while (savedMoney < neededMoney)
                {
                    double currentSavedMoney = double.Parse(Console.ReadLine());
                    savedMoney += currentSavedMoney;
                }
                Console.WriteLine($"Going to {destination}!" );
                destination = Console.ReadLine();
            }
        }
    }
}
