using System;

namespace _02_Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            int vowelsCount = VawelsCounter(input);
            
            Console.WriteLine(vowelsCount);
        }

        private static int VawelsCounter(string input)
        {
            int vowelsCount = 0;
            var vowels = "aeiouAEIOU";
            //var vowels = "aeiou";


            foreach (var letter in input) //foreach (var letter in input.ToLower())
            {
                if (vowels.Contains(letter))
                {
                    vowelsCount++;
                }
            }
            return vowelsCount;
        }
    }
}
