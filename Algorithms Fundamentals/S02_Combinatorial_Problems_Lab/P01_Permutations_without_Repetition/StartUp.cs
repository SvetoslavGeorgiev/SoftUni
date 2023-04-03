namespace P01_Permutations_without_Repetition
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        private static string[] elements;
        private static string[] permutations;
        private static bool[] used;
        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split()
                .ToArray();

            permutations = new string[elements.Length];

            used = new bool[elements.Length];

            Permut(0);
            
        }

        private static void Permut(int index)
        {
            if (index >= permutations.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutations[index] = elements[i];
                    Permut(index + 1);
                    used[i] = false;
                }
            }

        }
    }
}