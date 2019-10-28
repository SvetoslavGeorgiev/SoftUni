using System;

namespace Bachelor_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForSinger = double.Parse(Console.ReadLine());

            int guests = 0;
            double moneyForPeople = 0;

            string command = Console.ReadLine();

            while (command != "The restaurant is full")
            {

                int amountOfpeople = int.Parse(command);

                double moneyForTheGroup = 0;
                if (amountOfpeople < 5)
                {
                    moneyForTheGroup = amountOfpeople * 100;
                    moneyForPeople += moneyForTheGroup;
                }
                else
                {
                    moneyForTheGroup = amountOfpeople * 70;
                    moneyForPeople += moneyForTheGroup;
                }

                guests += amountOfpeople;

                command = Console.ReadLine();
            }
            double neededMoney = (moneyForPeople - moneyForSinger);
            if (moneyForPeople >= moneyForSinger)
            {
                Console.WriteLine($"You have {guests} guests and {neededMoney} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {guests} guests and {moneyForPeople} leva income, but no singer.");
            }
            
        }
    }
}
