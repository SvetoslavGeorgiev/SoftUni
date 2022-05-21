using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = Console.ReadLine()
              .Split()
              .Select(int.Parse)
              .ToArray();

            char[,] matrix = new char[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrixSize[0]; row++)
            {
                var command = new Queue<char>(Console.ReadLine()
                    .ToLower()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray());

                for (int col = 0; col < matrixSize[1]; col++)
                {

                    matrix[row, col] = command.Dequeue();
                }
            }

            var equalCharMatrix = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {

                    var element = matrix[row, col];


                    if (element == matrix[row, col + 1] &&
                        element == matrix[row + 1, col] &&
                        element == matrix[row + 1, col + 1])
                    {
                        equalCharMatrix++;
                    }
                }
            }

            Console.WriteLine(equalCharMatrix);
        }
    }
}
