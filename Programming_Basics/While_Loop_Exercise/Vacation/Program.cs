using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForHoliday = double.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());

            int daysCounter = 1;
            int spendCounter = 0;

            string spend = "spend";

            while (money < moneyForHoliday && spendCounter < 5)
            {
                string action = Console.ReadLine();
                double actionMoney = double.Parse(Console.ReadLine());

                if (action == spend)
                {
                    money -= actionMoney;
                    spendCounter++;
                }
                else
                {
                    money += actionMoney;
                    spendCounter = 0;
                }
                if (money < 0)
                {
                    money = 0;
                }
                if (money >= moneyForHoliday)
                {
                    Console.WriteLine($"You saved the money for {daysCounter} days.");
                    break;
                }
                if (spendCounter == 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine(daysCounter);
                }
                daysCounter++;
            }
        }
    }
}
