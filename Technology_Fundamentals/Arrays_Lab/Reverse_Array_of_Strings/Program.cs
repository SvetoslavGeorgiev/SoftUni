using System;

namespace Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string values = Console.ReadLine();
            string[] valuesAsStrings = values.Split();

            for (int i = valuesAsStrings.Length - 1; i >= 0; i--)
            {
                Console.Write($"{valuesAsStrings[i]} ");
            }
        }
    }
}
