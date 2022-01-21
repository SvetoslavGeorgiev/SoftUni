using System;

namespace _09_Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var amountOfMoney = double.Parse(Console.ReadLine());
            var students = int.Parse(Console.ReadLine());
            var priceOfLightsabers = double.Parse(Console.ReadLine());
            var priceOfRobes = double.Parse(Console.ReadLine());
            var priceOfBelts = double.Parse(Console.ReadLine());

            var freeBelts = (students / 6);
            var extraLightsabers = Math.Ceiling(students * 0.1);

            var neededMoney = ((students + extraLightsabers) * priceOfLightsabers) +
                (students * priceOfRobes) + ((students - freeBelts) * priceOfBelts);

            if (neededMoney <= amountOfMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {neededMoney:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {neededMoney - amountOfMoney:F2}lv more.");
            }
        }
    }
}
