using System;
using System.Collections.Generic;
using System.Linq;

namespace Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeOfTheMatrix = int.Parse(Console.ReadLine());

            var matrix = new char[sizeOfTheMatrix, sizeOfTheMatrix];

            for (int row = 0; row < sizeOfTheMatrix; row++)
            {
                var command = new Queue<char>(Console.ReadLine());

                for (int col = 0; col < sizeOfTheMatrix; col++)
                {
                    matrix[row, col] = command.Dequeue();
                }
            }

            int knight = 0;

            while (true)
            {
                int rowIndexOfTheKnight = -1;
                int colIndexOfTheKnight = -1;

                int attacs = 0;

                for (int row = 0; row < sizeOfTheMatrix; row++)
                {
                    for (int col = 0; col < sizeOfTheMatrix; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {

                            int currentAttac = CurrentAtack(matrix, row, col);

                            if (currentAttac > attacs)
                            {
                                attacs = currentAttac;
                                rowIndexOfTheKnight = row;
                                colIndexOfTheKnight = col;
                            }

                        }
                    }
                }

                if (attacs > 0)
                {
                    matrix[rowIndexOfTheKnight, colIndexOfTheKnight] = '0';
                    knight++;
                }
                else
                {
                    break;
                }

            }

            Console.WriteLine(knight);

        }

        private static int CurrentAtack(char[,] matrix, int row, int col)
        {
            var numberOfAtacs = 0;


            if (IsInTheMatrix(row - 1, col - 2, matrix) && matrix[row - 1, col - 2] == 'K')
            {
                numberOfAtacs++;
            }
            if (IsInTheMatrix(row - 1, col + 2, matrix) && matrix[row - 1, col + 2] == 'K')
            {
                numberOfAtacs++;
            }
            if (IsInTheMatrix(row + 1, col - 2, matrix) && matrix[row + 1, col - 2] == 'K')
            {
                numberOfAtacs++;
            }
            if (IsInTheMatrix(row + 1, col + 2, matrix) && matrix[row + 1, col + 2] == 'K')
            {
                numberOfAtacs++;
            }
            if (IsInTheMatrix(row - 2, col - 1, matrix) && matrix[row - 2, col - 1] == 'K')
            {
                numberOfAtacs++;
            }
            if (IsInTheMatrix(row - 2, col + 1, matrix) && matrix[row - 2, col + 1] == 'K')
            {
                numberOfAtacs++;
            }
            if (IsInTheMatrix(row + 2, col - 1, matrix) && matrix[row + 2, col - 1] == 'K')
            {
                numberOfAtacs++;
            }
            if (IsInTheMatrix(row + 2, col + 1, matrix) && matrix[row + 2, col + 1] == 'K')
            {
                numberOfAtacs++;
            }

            return numberOfAtacs;
        }

        private static bool IsInTheMatrix(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
