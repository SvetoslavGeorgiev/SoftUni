using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[,] matrix = new int[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrixSize[0]; row++)
            {
                var command = new Queue<int>(Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

                for (int col = 0; col < matrixSize[1]; col++)
                {

                    matrix[row, col] = command.Dequeue();
                }
            }


            var sum = int.MinValue;

            var rowIndex = 0;
            var colIndex = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    var currentSum = 0;
                    // WE CAN USE THIS VARIANT OR FOR LOOP DOWN BELOW!!!
                    //var currentSum =
                    //    matrix[row, col] +
                    //    matrix[row, col + 1] +
                    //    matrix[row, col + 2] +
                    //    matrix[row + 1, col] +
                    //    matrix[row + 1, col + 1] +
                    //    matrix[row + 1, col + 2] +
                    //    matrix[row + 2, col] +
                    //    matrix[row + 2, col + 1] +
                    //    matrix[row + 2, col + 2];


                    for (int r = row; r <= row + 2; r++)
                    {
                        for (int c = col; c <= col + 2; c++)
                        {
                            currentSum += matrix[r, c];
                        }
                    }

                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");

            for (int row = rowIndex; row < rowIndex + 3; row++)
            {
                for (int col = colIndex; col < colIndex + 3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
