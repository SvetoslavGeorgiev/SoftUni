namespace P02_Nested_Loops
{
    using System;

    internal class StartUp
    {
        private static int n;
        private static int k;
        private static int[] elements;
        private static int[] variations;


        static void Main(string[] args)
        {
            
            
            n = int.Parse(Console.ReadLine());

            elements = new int[n];

            for (int i = 0; i < n; i++)
            {
                elements[i] = i + 1;
            }

            k = n;

            variations = new int[k];

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