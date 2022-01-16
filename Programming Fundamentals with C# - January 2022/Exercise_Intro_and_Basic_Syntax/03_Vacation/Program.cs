using System;

namespace _03_Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var quantityOfTheGroup = int.Parse(Console.ReadLine());
            var typeOfTheGroup = Console.ReadLine();
            var vacationDay = Console.ReadLine();

            var priceForOnePerson = 0.00;

            switch (typeOfTheGroup)
            {
                case "Students":
                    switch (vacationDay)
                    {
                        case "Friday":
                            priceForOnePerson = 8.45;
                            break;
                        case "Saturday":
                            priceForOnePerson = 9.80;
                            break;
                        case "Sunday":
                            priceForOnePerson = 10.46;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Business":
                    switch (vacationDay)
                    {
                        case "Friday":
                            priceForOnePerson = 10.90;
                            break;
                        case "Saturday":
                            priceForOnePerson = 15.60;
                            break;
                        case "Sunday":
                            priceForOnePerson = 16.00;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Regular":
                    switch (vacationDay)
                    {
                        case "Friday":
                            priceForOnePerson = 15.00;
                            break;
                        case "Saturday":
                            priceForOnePerson = 20.00;
                            break;
                        case "Sunday":
                            priceForOnePerson = 22.50;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            var totalPrice = priceForOnePerson * quantityOfTheGroup;


            if (typeOfTheGroup == "Students" && quantityOfTheGroup >= 30)
            {
                totalPrice = totalPrice - (totalPrice * 0.15);
            }
            if (typeOfTheGroup == "Business" && quantityOfTheGroup >= 100)
            {
                totalPrice = (totalPrice - (priceForOnePerson * 10));
            }
            if (typeOfTheGroup == "Regular" && quantityOfTheGroup >= 10 && quantityOfTheGroup <=20)
            {
                totalPrice = totalPrice - (totalPrice * 0.05);
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}