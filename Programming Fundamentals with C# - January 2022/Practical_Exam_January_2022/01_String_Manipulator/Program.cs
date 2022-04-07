using System;

namespace _01_String_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {

                var tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var action = tokens[0];

                if (action == "Translate")
                {

                    var forReplace = char.Parse(tokens[1]);
                    var toReplace = char.Parse(tokens[2]);

                    input = input.Replace(forReplace, toReplace);
                    Console.WriteLine(input);
                }
                else if (action == "Includes")
                {
                    var stringToCheck = tokens[1];

                    Console.WriteLine(input.Contains(stringToCheck));

                }
                else if (action == "Start")
                {

                    var stringToCheck = tokens[1];


                    Console.WriteLine(input.StartsWith(stringToCheck));


                }
                else if (action == "Lowercase")
                {

                    input = input.ToLower();

                    Console.WriteLine(input);
                }
                else if (action == "FindIndex")
                {

                    var @char = char.Parse(tokens[1]);

                    var index = input.LastIndexOf(@char);

                    Console.WriteLine(index);

                }
                else
                {

                    var index = int.Parse(tokens[1]);
                    var count = int.Parse(tokens[2]);


                    input = input.Remove(index, count);
                    Console.WriteLine(input);
                }
            }
        }
    }
}
