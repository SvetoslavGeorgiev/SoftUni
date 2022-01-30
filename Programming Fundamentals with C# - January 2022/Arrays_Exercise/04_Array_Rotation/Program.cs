using System;
using System.Linq;

namespace _04_Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            var startFromIndex = int.Parse(Console.ReadLine());

            if (startFromIndex >= arr.Length)
            {
                startFromIndex = startFromIndex % arr.Length;

            }

            for (int i = startFromIndex; i <= arr.Length - 1; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            for (int i = 0; i < startFromIndex; i++)
            {
                Console.Write($"{arr[i]} ");
            }
        }
    }
}