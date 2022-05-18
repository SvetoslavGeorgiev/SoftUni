using System;
using System.Collections.Generic;

namespace P04_Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int r = 0; r < size; r++)
            {
                var element = new Queue<char>(Console.ReadLine().ToCharArray());

                for (int c = 0; c < size; c++)
                {
                    matrix[r, c] = element.Dequeue();
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            var counter = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        counter++;
                        return;
                    }
                }
            }
            if (counter == 0)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix ");
            }
        }
    }
}

