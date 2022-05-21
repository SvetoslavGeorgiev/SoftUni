using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sizeOfTheMatrix = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var snake = new Queue<char>(Console.ReadLine());

            var matrix = new char[sizeOfTheMatrix[0], sizeOfTheMatrix[1]];

            for (int row = 0; row < sizeOfTheMatrix[0]; row++)
            {
                for (int col = 0; col < sizeOfTheMatrix[1]; col++)
                {
                    var currentChar = snake.Dequeue();
                    matrix[row, col] = currentChar;

                    snake.Enqueue(currentChar);
                }
            }

            for (int row = 0; row < sizeOfTheMatrix[0]; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < sizeOfTheMatrix[1]; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                }
                else
                {
                    for (int col = sizeOfTheMatrix[1] - 1; col >= 0; col--)
                    {
                        Console.Write(matrix[row, col]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
