using System;
using System.Collections.Generic;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {

            var size = int.Parse(Console.ReadLine());

            var matrix = new string[size, size];

            var commandsToMove = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray());

            var startRow = 0;
            var startCol = 0;
            var coals = 0;

            for (int row = 0; row < size; row++)
            {
                var element = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray());

                for (int col = 0; col < size; col++)
                {
                    var currentElemnt = element.Dequeue();

                    if (currentElemnt == "s")
                    {
                        startRow = row;
                        startCol = col;
                    }

                    matrix[row, col] = currentElemnt;
                }
            }


            while (commandsToMove.Any())
            {

                var currentMove = commandsToMove.Dequeue().ToLower();


                if (currentMove == "up" && IsInTheMatrix(matrix, startRow - 1, startCol))
                {
                    startRow = startRow - 1;
                    if (matrix[startRow, startCol] == "c")
                    {
                        matrix[startRow, startCol] = "*";
                        coals++;
                    }
                    else if (matrix[startRow, startCol] == "e")
                    {
                        Console.WriteLine($"Game over! ({startRow}, {startCol})");
                        return;
                    }
                }
                else if (currentMove == "down" && IsInTheMatrix(matrix, startRow + 1, startCol))
                {
                    startRow = startRow + 1;
                    if (matrix[startRow, startCol] == "c")
                    {
                        matrix[startRow, startCol] = "*";
                        coals++;
                    }
                    else if (matrix[startRow, startCol] == "e")
                    {
                        Console.WriteLine($"Game over! ({startRow}, {startCol})");
                        return;
                    }
                }
                else if (currentMove == "left" && IsInTheMatrix(matrix, startRow, startCol - 1))
                {
                    startCol = startCol - 1;
                    if (matrix[startRow, startCol] == "c")
                    {
                        matrix[startRow, startCol] = "*";
                        coals++;
                    }
                    else if (matrix[startRow, startCol] == "e")
                    {
                        Console.WriteLine($"Game over! ({startRow}, {startCol})");
                        return;
                    }
                }
                else if (currentMove == "right" && IsInTheMatrix(matrix, startRow, startCol + 1))
                {
                    startCol = startCol + 1;
                    if (matrix[startRow, startCol] == "c")
                    {
                        matrix[startRow, startCol] = "*";
                        coals++;
                    }
                    else if (matrix[startRow, startCol] == "e")
                    {
                        Console.WriteLine($"Game over! ({startRow}, {startCol})");
                        return;
                    }
                }
            }

            var remainingCoals = RemainingCoals(matrix);

            if (remainingCoals > 0)
            {
                Console.WriteLine($"{remainingCoals} coals left. ({startRow}, {startCol})");
            }
            else
            {
                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
            }
        }

        private static int RemainingCoals(string[,] matrix)
        {
            var coals = 0;

            foreach (var item in matrix)
            {
                if (item == "c")
                {
                    coals++;
                }
            }

            return coals;
        }

        private static bool IsInTheMatrix(string[,] matrix, int startRow, int startCol)
        {
            return startRow >= 0 && startRow < matrix.GetLength(0) && startCol >= 0 && startCol < matrix.GetLength(1);
        }
    }
}
