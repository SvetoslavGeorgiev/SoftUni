using System;
using System.Text.RegularExpressions;

namespace P06_Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();


            var patern = @"([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)";

            var matches = Regex.Matches(input, patern);


            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
