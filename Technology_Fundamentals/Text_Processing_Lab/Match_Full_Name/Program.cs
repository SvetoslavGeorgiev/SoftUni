using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Match_Full_Name
{
    class Program
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
