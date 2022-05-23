using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                var element = new Queue<int>(Console.ReadLine()
                                             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                             .Select(int.Parse)
                                             .ToArray());

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = element.Dequeue();
                }
            }

            var coordinates = new Queue<string>(Console.ReadLine()
                                                .Split()
                                                .ToArray());


            while (coordinates.Any())
            {

                var currentCoordinates = coordinates.Dequeue()
                  .Split(",", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();


                CurrentExplosion(currentCoordinates, matrix);
            }

            var aliveCells = 0;
            var sum = 0;

            foreach (var item in matrix)
            {
                if (item > 0)
                {
                    aliveCells++;
                    sum += item;
                }
            }


            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

        }

        private static void CurrentExplosion(int[] currentCoordinates, int[,] matrix)
        {
            var row = currentCoordinates[0];
            var col = currentCoordinates[1];
            var bombValue = matrix[row, col];

            if (bombValue <= 0)
            {
                return;
            }


            if (IsInTheMatrix(row, col, matrix) && matrix[row, col] > 0)
            {
                matrix[row, col] = matrix[row, col] - bombValue;
            }
            if (IsInTheMatrix(row - 1, col - 1, matrix) && matrix[row - 1, col - 1] > 0)
            {
                matrix[row - 1, col - 1] = matrix[row - 1, col - 1] - bombValue;
            }
            if (IsInTheMatrix(row - 1, col, matrix) && matrix[row - 1, col] > 0)
            {
                matrix[row - 1, col] = matrix[row - 1, col] - bombValue;
            }
            if (IsInTheMatrix(row - 1, col + 1, matrix) && matrix[row - 1, col + 1] > 0)
            {
                matrix[row - 1, col + 1] = matrix[row - 1, col + 1] - bombValue;
            }
            if (IsInTheMatrix(row, col - 1, matrix) && matrix[row, col - 1] > 0)
            {
                matrix[row, col - 1] = matrix[row, col - 1] - bombValue;
            }
            if (IsInTheMatrix(row, col + 1, matrix) && matrix[row, col + 1] > 0)
            {
                matrix[row, col + 1] = matrix[row, col + 1] - bombValue;
            }
            if (IsInTheMatrix(row + 1, col, matrix) && matrix[row + 1, col] > 0)
            {
                matrix[row + 1, col] = matrix[row + 1, col] - bombValue;
            }
            if (IsInTheMatrix(row + 1, col + 1, matrix) && matrix[row + 1, col + 1] > 0)
            {
                matrix[row + 1, col + 1] = matrix[row + 1, col + 1] - bombValue;
            }
            if (IsInTheMatrix(row + 1, col - 1, matrix) && matrix[row + 1, col - 1] > 0)
            {
                matrix[row + 1, col - 1] = matrix[row + 1, col - 1] - bombValue;
            }
        }

        private static bool IsInTheMatrix(int row, int col, int[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
