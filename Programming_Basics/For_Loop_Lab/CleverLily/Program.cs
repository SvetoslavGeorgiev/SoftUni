using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double moneyForWasher = double.Parse(Console.ReadLine());
            double toyMoney = double.Parse(Console.ReadLine());

            double sumMoney = 0;

            for (int i = 1; i < age; i++)
            {
                if (i % 2 == 0)
                {
                    int moneyForBirthday = i * 10 - 1;
                    sumMoney += moneyForBirthday;
                }
                else
                {
                    sumMoney += toyMoney;
                }
            }
            if (sumMoney >= moneyForWasher)
            {
                Console.WriteLine($"Yes! {sumMoney - moneyForWasher:F2}");
            }
            else
            {
                Console.WriteLine($"No! {moneyForWasher - sumMoney:F2}");
            }
        }
    }
}
