using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P02_D_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine();

            var listOfDestinations = new List<string>();

            var patern = @"(=|\/)([A-Z][A-Za-z]{2,})\1";

            var matches = Regex.Matches(input, patern);

            var sumOfThePoints = 0;

            foreach (Match match in matches)
            {
                var currentDestination = match.Value.Trim(new[] { '=', '/' });

                listOfDestinations.Add(currentDestination);
                sumOfThePoints += currentDestination.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", listOfDestinations)}");
            Console.WriteLine($"Travel Points: {sumOfThePoints}");
        }
    }
}
