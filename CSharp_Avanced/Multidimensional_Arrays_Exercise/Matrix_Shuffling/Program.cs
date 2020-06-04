using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string[,] matrix = new string[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrixSize[0]; row++)
            {
                var command = new Queue<string>(Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
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
                    if (!IsNumber(currentCommand[1]) ||
                        !IsNumber(currentCommand[2]) ||
                        !IsNumber(currentCommand[3]) ||
                        !IsNumber(currentCommand[4]))
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                    else
                    {
                        var row1 = int.Parse(currentCommand[1]);
                        var col1 = int.Parse(currentCommand[2]);
                        var row2 = int.Parse(currentCommand[3]);
                        var col2 = int.Parse(currentCommand[4]);

                        if (row1 < 0 || row1 >= matrix.GetLength(0) || row2 < 0 || row2 >= matrix.GetLength(0) ||
                            col1 < 0 || col1 >= matrix.GetLength(1) || col2 < 0 || col2 >= matrix.GetLength(1))
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        else
                        {
                            var temp = matrix[row1, col1];

                            matrix[row1, col1] = matrix[row2, col2];

                            matrix[row2, col2] = temp;


                            for (int row = 0; row < matrixSize[0]; row++)
                            {
                                for (int col = 0; col < matrixSize[1]; col++)
                                {
                                    Console.Write($"{matrix[row, col]} ");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                    
                }
            }
        }

        private static bool IsNumber(string text)
        {
            int test;

            return int.TryParse(text, out test);
        }
    }
}
