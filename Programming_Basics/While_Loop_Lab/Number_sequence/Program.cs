using System;

namespace Number_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int max = int.MinValue;
            int min = int.MaxValue;

            while (true)
            {
                if (command == "END")
                {
                    break;
                }
                int number = int.Parse(command);
                if (max < number)
                {
                    max = number;
                }
                if (min > number)
                {
                    min = number;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Max number: {max}");
            Console.WriteLine($"Min number: {min}");
        }
    }
}
