using System;
using System.Text.RegularExpressions;

namespace P02_Message_Decrypter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfInputs = int.Parse(Console.ReadLine());


            for (int i = 0; i < numberOfInputs; i++)
            {

                var message = Console.ReadLine();

                var matches = Regex.Matches(message, @"^(\$|\%)(?<tag>[A-Z]{1}[a-z]{2,})\1(: )(\[)(?<firstChar>[0-9]{1,})(\])(\|)(\[)(?<secondChar>[0-9]{1,})(\])(\|)(\[)(?<thirdChar>[0-9]{1,})(\])(\|)$");


                if (matches.Count > 0)
                {

                    foreach (Match match in matches)
                    {
                        var tag = match.Groups["tag"].Value;

                        var firstChar = int.Parse(match.Groups["firstChar"].Value);
                        var secondChar = int.Parse(match.Groups["secondChar"].Value);
                        var thirdChar = int.Parse(match.Groups["thirdChar"].Value);

                        Console.WriteLine($"{tag}: {(char)firstChar}{(char)secondChar}{(char)thirdChar}");

                    }
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }

            }
        }
    }
}