using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Sum_Matrix_Elements
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
            var sum = 0;
            foreach (var item in matrix)
            {
                sum += item;
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
