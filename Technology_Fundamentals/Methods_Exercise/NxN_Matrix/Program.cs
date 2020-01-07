using System;

namespace NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            PrintAnMAtrixWithGivenSize(matrixSize);
        }

        private static void PrintAnMAtrixWithGivenSize(int matrixSize)
        {
            for (int i = 1; i <= matrixSize; i++)
            {
                for (int k = 1; k <= matrixSize; k++)
                {
                    Console.Write($"{matrixSize} ");
                }
                Console.WriteLine();
            }
        }
    }
}
