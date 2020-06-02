using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Matrix_Shuffling
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

            var command2 = string.Empty;
            while ((command2 = Console.ReadLine().ToLower()) != "end")
            {
                var currentCommand = command2.Split().ToArray();

                if (currentCommand[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {

                }




            }
        }
    }
}
