using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P02_Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var matches = Regex.Matches(input, @"(?<!\d)[+]359([- ])2\1\d{3}\1\d{4}\b");
            List<string> list = matches
                .Cast<Match>()
                .Select(x => x.Value.Trim())
                .ToList();

            Console.WriteLine(string.Join(", ", list));
        }
    }
}