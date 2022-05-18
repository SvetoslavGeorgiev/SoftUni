using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                var element = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = element.Dequeue();
                }
            }



            int maxRow = 0;
            int maxCol = 0;

            var maxSum = int.MinValue;

            for (int row = 0; row < size[0] - 1; row++)
            {

                for (int col = 0; col < size[1] - 1; col++)
                {
                    var currentSum = matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;

                        maxRow = row;
                        maxCol = col;

                    }
                }
            }

            Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]}");
            Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
