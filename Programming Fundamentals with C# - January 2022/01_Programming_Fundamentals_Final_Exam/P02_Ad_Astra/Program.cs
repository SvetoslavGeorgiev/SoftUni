using System;
using System.Text.RegularExpressions;

namespace P02_Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();


            var matches = Regex.Matches(input, @"(#|\|)(?<food>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d{1,})\1");


            var dayCalories = 2000;

            var totalCalories = 0;

            foreach (Match match in matches)
            {
                var calories = int.Parse(match.Groups["calories"].Value);
                totalCalories += calories;
            }

            var foodForNumberOfDays = totalCalories / dayCalories;

            Console.WriteLine($"You have food to last you for: {foodForNumberOfDays} days!");

            foreach (Match match in matches)
            {
                var date = match.Groups["date"].Value;
                var food = match.Groups["food"].Value;
                var calories = int.Parse(match.Groups["calories"].Value);


                Console.WriteLine($"Item: {food}, Best before: {date}, Nutrition: {calories}");
            }
        }
    }
}
