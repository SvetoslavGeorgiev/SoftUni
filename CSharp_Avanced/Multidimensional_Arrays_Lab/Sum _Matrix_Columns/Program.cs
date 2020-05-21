using System;
using System.Collections.Generic;
using System.Linq;

namespace Sum__Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                var element = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = element.Dequeue();
                }
            }
            for (int col = 0; col < size[1]; col++)
            {
                var sum = 0;
                for (int row = 0; row < size[0]; row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
            }
            
        }
    }
}
