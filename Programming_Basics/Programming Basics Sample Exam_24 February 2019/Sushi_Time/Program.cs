using System;

namespace Sushi_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            string sushi = Console.ReadLine();
            string restorantName = Console.ReadLine();

            int portions = int.Parse(Console.ReadLine());
            char typeOrder = char.Parse(Console.ReadLine());

            double price = 0;

            switch (restorantName)
            {
                case "Sushi Zone":
                    
                    if (sushi == "sashimi")
                    {
                        price = 4.99;
                    }
                    else if (sushi == "maki")
                    {
                        price = 5.29;
                    }
                    else if (sushi == "uramaki")
                    {
                        price = 5.99;
                    }
                    else if (sushi == "temaki")
                    {
                        price = 4.29;
                    }
                    break;
                case "Sushi Time":
                    if (sushi == "sashimi")
                    {
                        price = 5.49;
                    }
                    else if (sushi == "maki")
                    {
                        price = 4.69;
                    }
                    else if (sushi == "uramaki")
                    {
                        price = 4.49;
                    }
                    else if (sushi == "temaki")
                    {
                        price = 5.19;
                    }
                    break;
                case "Sushi Bar":
                    if (sushi == "sashimi")
                    {
                        price = 5.25;
                    }
                    else if (sushi == "maki")
                    {
                        price = 5.55;
                    }
                    else if (sushi == "uramaki")
                    {
                        price = 6.25;
                    }
                    else if (sushi == "temaki")
                    {
                        price = 4.75;
                    }
                    break;
                case "Asian Pub":
                    if (sushi == "sashimi")
                    {
                        price = 4.50;
                    }
                    else if (sushi == "maki")
                    {
                        price = 4.80;
                    }
                    else if (sushi == "uramaki")
                    {
                        price = 5.50;
                    }
                    else if (sushi == "temaki")
                    {
                        price = 5.50;
                    }
                    break;
                default:
                    Console.WriteLine($"{restorantName} is invalid restaurant!");
                    return;
                    
            }
            if (typeOrder == 'Y')
            {
                price = price + (price * 0.20);
            }
            
            double totalPrice = Math.Ceiling(price * portions);

            Console.WriteLine($"Total price: {totalPrice} lv.");
        }
    }
}
