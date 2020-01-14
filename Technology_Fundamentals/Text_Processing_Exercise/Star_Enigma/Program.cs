using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            var nuberOfMesseges = int.Parse(Console.ReadLine());
            var decryptedMessage = string.Empty;

            var attackedPlanets = new List<string>();
            var destroyedPlanets = new List<string>();

            for (int i = 0; i < nuberOfMesseges; i++)
            {

                var command = Console.ReadLine();

                var pattern = @"[starSTAR]";
                var code = 0;

                if (Regex.IsMatch(command, pattern))
                {
                    var matches = Regex.Matches(command, pattern);

                    code = matches.Count;
                }

                foreach (var @char in command)
                {
                    decryptedMessage += (char)(@char - code);
                }
                var pattern2 = @"\@(?<name>[A-Za-z]+)[^\@\-\!\:\>]*\:(?<population>[0-9]+)[^\@\-\!\:\>]*\!(?<type>[A-Z]{1})\![^\@\-\!\:\>]*\->(?<soldiers>[0-9]+)";

                var matches2 = Regex.Matches(decryptedMessage, pattern2);

                decryptedMessage = string.Empty;

                foreach (Match match in matches2)
                {
                    var type = char.Parse(match.Groups["type"].ToString());
                    var name = match.Groups["name"].ToString();

                    if (type == 'A')
                    {
                        attackedPlanets.Add(name);
                    }
                    else
                    {
                        destroyedPlanets.Add(name);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            if (attackedPlanets.Count >= 1)
            {
                for (int i = 0; i < attackedPlanets.Count; i++)
                {
                    Console.WriteLine($"-> {attackedPlanets[i]}");
                }
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            if (destroyedPlanets.Count >= 1)
            {
                for (int i = 0; i < destroyedPlanets.Count; i++)
                {
                    Console.WriteLine($"-> {destroyedPlanets[i]}");
                }
            }
        }
    }
}
