using System;
using System.Text.RegularExpressions;

namespace P03_Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var dates = Regex.Matches(input, @"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b");

            foreach (Match match in dates)
            {
                Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["month"]}, Year: {match.Groups["year"]}");
            }
        }
    }
}