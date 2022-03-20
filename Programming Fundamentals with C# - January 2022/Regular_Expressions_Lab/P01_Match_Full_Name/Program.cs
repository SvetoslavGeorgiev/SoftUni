using System;
using System.Text.RegularExpressions;

namespace P1_Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var matches = Regex.Matches(input, @"\b[A-Z][a-z]+[' '][A-Z][a-z]+\b");

            foreach (Match match in matches)
            {
                Console.Write($"{match.Value} ");
            }
        }
    }
}