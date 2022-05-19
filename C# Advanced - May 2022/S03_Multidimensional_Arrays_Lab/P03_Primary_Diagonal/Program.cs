using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Primary_Diagonal
{
    internal class Program
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
            var sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += matrix[row, col];
                row++;
                col++;
            }

            Console.WriteLine(sum);
        }
    }
}
