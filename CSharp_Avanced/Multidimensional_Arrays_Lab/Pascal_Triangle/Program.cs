using System;

namespace Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] piramide = new long[rows][];
            if (rows == 1)
            {
                piramide[0] = new long[1];
                piramide[0][0] = 1;
                Console.WriteLine("1");
                return;
            }
            else
            {
                piramide[0] = new long[1];
                piramide[0][0] = 1;
            }
            if (rows == 2)
            {
                piramide[1] = new long[2];
                piramide[1][0] = 1;
                piramide[1][1] = 1;

                Console.WriteLine("1");
                Console.WriteLine("1 1");
                return;
            }
            else
            {

                piramide[1] = new long[2];
                piramide[1][0] = 1;
                piramide[1][1] = 1;
            }
            for (int row = 2; row < rows; row++)
            {
                piramide[row] = new long[row + 1];
                for (int col = 0; col < row + 1; col++)
                {
                    if (col == 0 || col == row)
                    {
                        piramide[row][col] = 1;
                    }
                    else
                    {
                        piramide[row][col] = piramide[row - 1][col] + piramide[row - 1][col - 1];
                    }
                }
            }


            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < piramide[row].Length; col++)
                {
                    Console.Write($"{piramide[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
