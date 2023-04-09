namespace P04_Variations_with_Repetition
{
    using System;

    internal class StartUp
    {
        private static int k;
        private static string[] elements;
        private static string[] variations;


        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());

            variations = new string[k];

            Variations(0);
        }

        private static void Variations(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {

                variations[index] = elements[i];
                Variations(index + 1);
            }
        }
    }
}