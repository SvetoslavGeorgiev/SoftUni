using System;

namespace CleverLily2
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double moneyForWasher = double.Parse(Console.ReadLine());
            double toyMoney = double.Parse(Console.ReadLine());

            double sumMoney = 0;
            int moneyForBirthday = 10;
            int brotherMoney = 1;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    
                    sumMoney += moneyForBirthday;
                    sumMoney -= brotherMoney;
                    moneyForBirthday += 10;
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
