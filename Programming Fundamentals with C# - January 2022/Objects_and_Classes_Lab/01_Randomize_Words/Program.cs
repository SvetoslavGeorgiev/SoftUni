using System;
using System.Linq;

namespace _01_Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Random randomNumber = new Random();

            var arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();


            for (int i = 0; i < arr.Length; i++)
            {
                var RrandomIndex = randomNumber.Next(0, arr.Length);

                var current = arr[i];
                arr[i] = arr[RrandomIndex];
                arr[RrandomIndex] = current;
            }

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
