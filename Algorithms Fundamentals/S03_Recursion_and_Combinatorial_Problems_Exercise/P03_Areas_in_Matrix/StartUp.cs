namespace P03_Areas_in_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Area
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }
    }

    internal class StartUp
    {
        static char[,] matrix;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string elements = Console.ReadLine();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = elements[j];
                }
            }

            List<Area> areas = new List<Area>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Area area = new Area() { Row = i, Col = j };
                    Explore(i, j, area);
                    if (area.Size != 0) areas.Add(area);
                }
            }

            Print(areas);
        }

        private static void Print(List<Area> areas)
        {
            int n = 1;
            Console.WriteLine($"Total areas found: {areas.Count}");
            foreach (Area area in areas.OrderByDescending(x => x.Size).ThenBy(x => x.Row).ThenBy(x => x.Col))
            {
                Console.WriteLine($"Area #{n} at ({area.Row}, {area.Col}), size: {area.Size}");
                n++;
            }
        }

        private static void Explore(int row, int col, Area area)
        {
            if (IsInvalid(row, col))
            {
                return;
            }

            area.Size++;
            matrix[row, col] = 'v';

            Explore(row + 1, col, area);
            Explore(row - 1, col, area);
            Explore(row, col + 1, area);
            Explore(row, col - 1, area);
        }

        private static bool IsInvalid(int row, int col)
        {
            return row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1)
            || matrix[row, col] == 'v' || matrix[row, col] == '*';
        }
    }
}