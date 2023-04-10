namespace P06_Combinations_with_Repetition
{
    using System;
    internal class StartUp
    {
        private static int k;
        private static string[] elements;
        private static string[] combinations;


        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());

            combinations = new string[k];

            GetCombinations(0, 0);
        }

        private static void GetCombinations(int index, int startIndex)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = startIndex; i < elements.Length; i++)
            {

                combinations[index] = elements[i];
                GetCombinations(index + 1, i);
            }
        }
    }
}