namespace P02_Permutations_with_Repetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {

        private static string[] elements;

        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split()
            .ToArray();

            Permut(0);
        }

        private static void Permut(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));

                return;
            }

            Permut(index + 1);

            var used = new HashSet<string> { elements[index] };

            for (int i = index + 1; i < elements.Length; i++)
            {

                if (!used.Contains(elements[i]))
                {
                    Swap(index, i);
                    Permut(index + 1);
                    Swap(index, i);

                    used.Add(elements[i]);
                }
            }
        }

        private static void Swap(int index, int secondIndex)
        {
            var temp = elements[index];
            elements[index] = elements[secondIndex];
            elements[secondIndex] = temp;
        }
    }
}