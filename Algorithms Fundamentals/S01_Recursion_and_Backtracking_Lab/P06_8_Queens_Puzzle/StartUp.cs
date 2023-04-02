namespace P06_8_Queens_Puzzle
{
    using System;

    internal class StartUp
    {
        static int[] columns = new int[8]; // to store column positions of queens
        static int solutionsCount = 0; // to count the number of solutions found


        static void Main(string[] args)
        {
            FindAllSolutions(0); // start the recursive search from row 0
            Console.WriteLine($"Found {solutionsCount} solutions.");
        }


        static void FindAllSolutions(int row)
        {
            if (row == 8) // found a valid solution
            {
                solutionsCount++;
                PrintSolution();
                return;
            }

            for (int col = 0; col < 8; col++) // try all possible columns in this row
            {
                if (IsSafe(row, col)) // if the current position is safe, place a queen there
                {
                    columns[row] = col;
                    FindAllSolutions(row + 1); // recursively search for the rest of the queens
                }
            }
        }

        static bool IsSafe(int row, int col)
        {
            // check if no other queen can attack this position
            for (int i = 0; i < row; i++)
            {
                if (columns[i] == col || // same column
                    columns[i] - i == col - row || // same diagonal (\)
                    columns[i] + i == col + row) // same diagonal (/)
                {
                    return false;
                }
            }
            return true;
        }

        static void PrintSolution()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (columns[row] == col)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}