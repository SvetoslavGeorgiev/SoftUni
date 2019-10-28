using System;

namespace Match_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            double numberOfPeople = double.Parse(Console.ReadLine());
            double moneyForTrasnport = 0;
            double leftOverMoney = 0;
            double finalLeftOverMoney = 0;

            if (numberOfPeople >= 1 && numberOfPeople <= 4)
            {
                moneyForTrasnport = budget * 0.75;
            }
            else if (numberOfPeople >= 5 && numberOfPeople <= 9)
            {
                moneyForTrasnport = budget * 0.60;
            }
            else if (numberOfPeople >= 10 && numberOfPeople <= 24)
            {
                moneyForTrasnport = budget * 0.50;
            }
            else if (numberOfPeople >= 25 && numberOfPeople <= 49)
            {
                moneyForTrasnport = budget * 0.40;
            }
            else if (numberOfPeople >= 50)
            {
                moneyForTrasnport = budget * 0.25;
            }
            leftOverMoney = budget - moneyForTrasnport;
            if (category == "VIP")
            {
                finalLeftOverMoney = leftOverMoney - (numberOfPeople * 499.99);
                if (finalLeftOverMoney >= 0)
                { 
                    Console.WriteLine($"Yes! You have {finalLeftOverMoney:F2} leva left.");
                }
                else if (finalLeftOverMoney < 0)
                {

                    Console.WriteLine($"Not enough money! You need {(finalLeftOverMoney * -1):f2} leva.");
                }
            }
            else if (category == "Normal")
            {
                finalLeftOverMoney = leftOverMoney - (numberOfPeople * 249.99);
                if (finalLeftOverMoney >= 0)
                {
                    Console.WriteLine($"Yes! You have {finalLeftOverMoney:F2} leva left.");
                }
                else if (finalLeftOverMoney < 0)
                {
                    Console.WriteLine($"Not enough money! You need {(finalLeftOverMoney * -1):f2} leva.");
                }
            }
        }
    }
}
