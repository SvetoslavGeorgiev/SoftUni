using System;

namespace New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());

            double Roses = 5.00;
            double Dahlias = 3.80;
            double Tulips = 2.80;
            double Narcissus = 3.00;
            double Gladiolus = 2.50;

            double totalAmount = 0;

            if (type == "Roses")
            {
                if (quantity <= 80)
                {
                    totalAmount = Roses * quantity;
                }
                else if (quantity > 80)
                {
                    totalAmount = (Roses - (Roses * 0.10)) * quantity;
                }
            }
            else if (type == "Dahlias")
            {
                if (quantity <= 90)
                {
                    totalAmount = Dahlias * quantity;
                }
                else if (quantity > 90)
                {
                    totalAmount = (Dahlias - (Dahlias * 0.15)) * quantity;
                }
            }
            else if (type == "Tulips")
            {
                if (quantity <= 80)
                {
                    totalAmount = Tulips * quantity;
                }
                else if (quantity > 80)
                {
                    totalAmount = (Tulips - (Tulips * 0.15)) * quantity;
                }
            }
            else if (type == "Narcissus")
            {
                if (quantity > 120)
                {
                    totalAmount = Narcissus * quantity;
                }
                else if (quantity < 120)
                {
                    totalAmount = (Narcissus + (Narcissus * 0.15)) * quantity;
                }
            }
            else if (type == "Gladiolus")
            {
                if (quantity > 80)
                {
                    totalAmount = Gladiolus * quantity;
                }
                else if (quantity < 80)
                {
                    totalAmount = (Gladiolus + (Gladiolus * 0.20)) * quantity;}
                }
            if (money > totalAmount)
            {
                Console.WriteLine($"Hey, you have a great garden with {quantity} {type} and {(money - totalAmount):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {(totalAmount - money):F2} leva more.");
            }
        }
    }
}
