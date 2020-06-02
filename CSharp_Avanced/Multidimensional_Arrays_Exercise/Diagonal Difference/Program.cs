using System;
using System.Collections.Generic;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int r = 0; r < size; r++)
            {
                var element = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

                for (int c = 0; c < size; c++)
                {
                    matrix[r, c] = element.Dequeue();
                }
            }

            var row = 0;
            var col = 0;
            var col2 = size;
            var sum = 0;
            var sum2 = 0;
            for (int i = 0; i < size; i++)
            {
                sum += matrix[row, col];
                sum2 += matrix[row, col2 - 1];
                col2--;
                row++;
                col++;
            }

            var diff = Math.Abs(sum - sum2);

            Console.WriteLine(diff);
        }
    }
}
