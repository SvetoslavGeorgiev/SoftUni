using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine();

            var matches = Regex.Matches(input, @"[+]359([- ])\d{1,2}\1\d{3}\1\d{4}\b");
            List<string> list = matches
                .Cast<Match>()
                .Select(x => x.Value.Trim())
                .ToList();

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
