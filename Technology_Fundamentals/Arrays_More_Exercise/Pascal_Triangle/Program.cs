using System;

namespace P02_PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            Console.WriteLine(1);

            if (numberOfRows == 1)
            {
                return;
            }

            int[] initialArray = new int[] { 1, 1 };
            Console.WriteLine(string.Join(" ", initialArray));

            if (numberOfRows == 2)
            {
                return;
            }

            else
            {
                for (int i = 0; i < initialArray.Length + 1; i++)
                {
                    int[] array = new int[initialArray.Length + 1];
                    array[0] = 1;
                    array[array.Length - 1] = 1;

                    for (int j = 1; j < array.Length - 1; j++)
                    {
                        array[j] = initialArray[j - 1] + initialArray[j];
                    }
                    Console.WriteLine(string.Join(" ", array));

                    initialArray = array;

                    if (initialArray.Length == numberOfRows)
                    {
                        break;
                    }
                }
            }
        }
    }
}