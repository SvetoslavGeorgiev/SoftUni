using System;
using System.Text.RegularExpressions;

namespace P06_Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var matches = Regex.Matches(input, @"((?<user>(?<=\n| )[a-zA-Z0-9]([\w\.\-]*)(?<!-))@(?<host>[\w\-]+)(\.(\w){2,}([\.-][\w]{2,})?))");


            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
