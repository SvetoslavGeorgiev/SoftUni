using System;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                var reversedCommand = string.Empty;

                for (int i = command.Length - 1; i >= 0; i--)
                {
                    reversedCommand += command[i];
                }

                Console.WriteLine($"{command} = {reversedCommand}");
            }
        }
    }
}
