namespace P05_Paths_in_Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var colElements = Console.ReadLine();

                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = colElements[c];
                }
            }

            FindPaths(matrix, 0, 0, new List<string>(), string.Empty);
        }

        private static void FindPaths(char[,] matrix, int row, int col, List<string> directions, string direction)
        {

            if (!IsInTheMatrix(row, col, matrix))
                return;

            if (matrix[row, col] == '*' || matrix[row, col] == 'V')
                return;

            directions.Add(direction);

            if (IsExit(row, col, matrix))
            {
                PrintMatrix(directions);
                return;
            }

            matrix[row, col] = 'V';


            FindPaths(matrix, row - 1, col, directions, "U");
            FindPaths(matrix, row, col - 1, directions, "L");
            FindPaths(matrix, row + 1, col, directions, "D");
            FindPaths(matrix, row, col + 1, directions, "R");

            matrix[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }

        private static void PrintMatrix(List<string> directions)
        {
            Console.WriteLine(string.Join(string.Empty, directions));
            directions.RemoveAt(directions.Count - 1);
        }

        private static bool IsExit(int row, int col, char[,] matrix)
        {
            return matrix[row, col] == 'e';
        }

        private static bool IsInTheMatrix(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}