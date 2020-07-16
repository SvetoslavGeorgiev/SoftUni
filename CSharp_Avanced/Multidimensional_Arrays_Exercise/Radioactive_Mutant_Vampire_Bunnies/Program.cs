using System;
using System.Collections.Generic;
using System.Linq;

namespace Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[size[0], size[1]];

            var startRow = 0;
            var startCol = 0;

            for (int row = 0; row < size[0]; row++)
            {
                var element = Console.ReadLine().ToUpper();

                for (int col = 0; col < size[1]; col++)
                {
                    var currentElemnt = element[col];

                    if (currentElemnt == 'P')
                    {
                        startRow = row;
                        startCol = col;
                    }

                    matrix[row, col] = currentElemnt;
                }
            }

            var commands = Console.ReadLine().ToLower();

            var bunniesRows = new Queue<int>();
            var bunniesCol = new Queue<int>();
            var deadPlayer = 0;


            for (int i = 0; i < commands.Length; i++)
            {

                var currentCommand = commands[i];

                if (currentCommand == 'u' && IsInTheMatrix(matrix, startRow - 1, startCol))
                {
                    if (matrix[startRow - 1, startCol] == 'B')
                    {
                        deadPlayer++;
                    }
                    else
                    {
                        matrix[startRow - 1, startCol] = 'P';
                    }
                    matrix[startRow, startCol] = '.';
                    startRow = startRow - 1;

                    deadPlayer = BunniesSpread(matrix, bunniesRows, bunniesCol, size, deadPlayer);

                    if (deadPlayer > 0)
                    {
                        PrintTheMatrix(matrix);
                        Console.WriteLine($"dead: {startRow} {startCol}");
                        return;
                    }
                }
                else if (currentCommand == 'd' && IsInTheMatrix(matrix, startRow + 1, startCol))
                {
                    if (matrix[startRow + 1, startCol] == 'B')
                    {
                        deadPlayer++;
                    }
                    else
                    {
                        matrix[startRow + 1, startCol] = 'P';
                    }
                    matrix[startRow, startCol] = '.';
                    startRow = startRow + 1;

                    deadPlayer = BunniesSpread(matrix, bunniesRows, bunniesCol, size, deadPlayer);

                    if (deadPlayer > 0)
                    {
                        PrintTheMatrix(matrix);
                        Console.WriteLine($"dead: {startRow} {startCol}");
                        return;
                    }
                }
                else if (currentCommand == 'l' && IsInTheMatrix(matrix, startRow, startCol - 1))
                {
                    if (matrix[startRow, startCol - 1] == 'B')
                    {
                        deadPlayer++;
                    }
                    else
                    {
                        matrix[startRow, startCol - 1] = 'P';
                    }
                    matrix[startRow, startCol] = '.';
                    startCol = startCol - 1;

                    deadPlayer = BunniesSpread(matrix, bunniesRows, bunniesCol, size, deadPlayer);

                    if (deadPlayer > 0)
                    {
                        PrintTheMatrix(matrix);
                        Console.WriteLine($"dead: {startRow} {startCol}");
                        return;
                    }
                }
                else if (currentCommand == 'r' && IsInTheMatrix(matrix, startRow, startCol + 1))
                {
                    if (matrix[startRow, startCol + 1] == 'B')
                    {
                        deadPlayer++;
                    }
                    else
                    {
                        matrix[startRow, startCol + 1] = 'P';
                    }
                    matrix[startRow, startCol] = '.';
                    startCol = startCol + 1;

                    deadPlayer = BunniesSpread(matrix, bunniesRows, bunniesCol, size, deadPlayer);

                    if (deadPlayer > 0)
                    {
                        PrintTheMatrix(matrix);
                        Console.WriteLine($"dead: {startRow} {startCol}");
                        return;
                    }
                }
                else if (currentCommand == 'u' && !IsInTheMatrix(matrix, startRow - 1, startCol) ||
                         currentCommand == 'd' && !IsInTheMatrix(matrix, startRow + 1, startCol) ||
                         currentCommand == 'l' && !IsInTheMatrix(matrix, startRow, startCol - 1) ||
                         currentCommand == 'r' && !IsInTheMatrix(matrix, startRow, startCol + 1))
                {
                     matrix[startRow, startCol] = '.';
                     BunniesSpread(matrix, bunniesRows, bunniesCol, size, deadPlayer);
                     PrintTheMatrix(matrix);
                     Console.WriteLine($"won: {startRow} {startCol}");
                     return;
                }
            }
        }

        private static void PrintTheMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static int BunniesSpread(char[,] matrix, Queue<int> bunniesRows, Queue<int> bunniesCol, int[] size, int deadPlayer)
        {
            for (int row = 0; row < size[0]; row++)
            {
                for (int col = 0; col < size[1]; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunniesRows.Enqueue(row);
                        bunniesCol.Enqueue(col);
                    }
                }
            }



            while (bunniesRows.Any())
            {
                var row = bunniesRows.Dequeue();
                var col = bunniesCol.Dequeue();

                if (IsInTheMatrix(matrix, row - 1, col) && matrix[row - 1, col] != 'P')
                {
                    matrix[row - 1, col] = 'B';
                }
                else if (IsInTheMatrix(matrix, row - 1, col) && matrix[row - 1, col] == 'P')
                {
                    matrix[row - 1, col] = 'B';
                    deadPlayer++;
                }
                if (IsInTheMatrix(matrix, row + 1, col) && matrix[row + 1, col] != 'P')
                {
                    matrix[row + 1, col] = 'B';
                }
                else if (IsInTheMatrix(matrix, row + 1, col) && matrix[row + 1, col] == 'P')
                {
                    matrix[row + 1, col] = 'B';
                    deadPlayer++;
                }
                if (IsInTheMatrix(matrix, row, col - 1) && matrix[row, col - 1] != 'P')
                {
                    matrix[row, col - 1] = 'B';
                }
                else if (IsInTheMatrix(matrix, row, col - 1) && matrix[row, col - 1] == 'P')
                {
                    matrix[row, col - 1] = 'B';
                    deadPlayer++;
                }
                if (IsInTheMatrix(matrix, row, col + 1) && matrix[row, col + 1] != 'P')
                {
                    matrix[row, col + 1] = 'B';
                }
                else if (IsInTheMatrix(matrix, row, col + 1) && matrix[row, col + 1] == 'P')
                {
                    matrix[row, col + 1] = 'B';
                    deadPlayer++;
                }
            }
            return deadPlayer;
        }

        private static bool IsInTheMatrix(char[,] matrix, int startRow, int startCol)
        {
            return startRow >= 0 && startRow < matrix.GetLength(0) && startCol >= 0 && startCol < matrix.GetLength(1);
        }
    }
}



