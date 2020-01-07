using System;

namespace Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while (command != "END")
            {
                if (int.TryParse(command, out int number))
                {
                    Console.WriteLine($"{command} is integer type");
                }
                else if (double.TryParse(command, out double floatingNumber))
                {
                    Console.WriteLine($"{command} is floating point type");
                }
                else if (bool.TryParse(command, out bool check))
                {
                    Console.WriteLine($"{command} is boolean type");
                }
                else if (char.TryParse(command, out char symbol))
                {
                    Console.WriteLine($"{command} is character type");
                }
                else
                {
                    Console.WriteLine($"{command} is string type");
                }
                command = Console.ReadLine();
            }
        }
    }
}
