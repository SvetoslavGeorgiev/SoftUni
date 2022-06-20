using System;

namespace P02_Survivor
{
    public class P02_Survivor
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            var beach = new string[rows][];

            var myTokens = 0;
            var opponentTokens = 0;

            for (int row = 0; row < rows; row++)
            {
                var currentCol = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                beach[row] = currentCol;
            }

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "Gong")
            {

                var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var currentRow = int.Parse(tokens[1]);
                var currentCol = int.Parse(tokens[2]);

                var isInIt = IsInTheMatrix(currentRow, currentCol, beach);

                if (isInIt)
                {
                    if (tokens[0] == "Find")
                    {

                        if (isInIt)
                        {
                            if (beach[currentRow][currentCol] == "T")
                            {
                                myTokens++;
                                beach[currentRow][currentCol] = "-";
                            }
                        }
                    }
                    else if (tokens[0] == "Opponent")
                    {
                        var direction = tokens[3];

                        opponentTokens = Move(opponentTokens, currentRow, currentCol, direction, beach);


                    }
                }
            }
            PrintMatrix(beach);
            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        private static void PrintMatrix(string[][] beach)
        {
            for (int row = 0; row < beach.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", beach[row]));
            }
        }

        private static int Move(int opponentTokens, int currentRow, int currentCol, string direction, string[][] beach)
        {
            if (IsInTheMatrix(currentRow, currentCol, beach))
            {
                if (beach[currentRow][currentCol] == "T")
                {
                    opponentTokens++;
                    beach[currentRow][currentCol] = "-";
                }
            }

            
            for (int i = 0; i < 3; i++)
            {
                (currentRow, currentCol) = GetNewCordinates(currentRow, currentCol, direction);
                if (IsInTheMatrix(currentRow, currentCol, beach))
                {
                    if (beach[currentRow][currentCol] == "T")
                    {
                        opponentTokens++;
                        beach[currentRow][currentCol] = "-";
                    }
                }
            }

            return opponentTokens;
        }

        

        private static (int currentRow, int currentCol) GetNewCordinates(int currentRow, int currentCol, string direction)
        {
            switch (direction)
            {
                case "up":
                    return (currentRow - 1, currentCol);
                case "down":
                    return (currentRow + 1, currentCol);
                case "left":
                    return (currentRow, currentCol - 1);
                case "right":
                    return (currentRow, currentCol + 1);
            }
            return (currentRow, currentCol);
        }

        private static bool IsInTheMatrix(int row, int col, string[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
        }
    }
}
