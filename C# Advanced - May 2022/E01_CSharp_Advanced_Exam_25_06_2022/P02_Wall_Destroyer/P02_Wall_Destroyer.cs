using System;
using System.Linq;
using System.Text;

namespace P02_Wall_Destroyer
{
    public class P02_Wall_Destroyer
    {
        static void Main()
        {
            (var vanko, var cables, var rods, var hole, bool electrocuted ,var electrocutedLetter) = ("V", "C", "R", "*", false, "E");
            (var playerRow, var playerCol, var rodesCount, var holes) = (0, 0, 0, 1);
            var size = int.Parse(Console.ReadLine());
            var matrix = new string[size, size];

            for (int row = 0; row < size; row++)
            {
                var element = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = element[col].ToString();
                    if (matrix[row, col] == vanko)
                    {
                        (playerRow, playerCol) = (row, col);
                    }
                }
            }

            

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                if (electrocuted)
                {
                    break;
                }

                (playerRow, playerCol, holes, electrocuted, rodesCount) = Move(playerRow, playerCol, command, matrix, rods, holes, vanko, electrocuted, rodesCount, electrocutedLetter, cables, hole);


            }
            if (electrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes + 1} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rodesCount} rod(s).");
            }
            Print(matrix);

        }
        private static void Print(string[,] matrix)
        {
            var sb = new StringBuilder();


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.Append(matrix[row, col]);
                }
                Console.WriteLine(sb);
                sb.Clear();
            }
        }

        private static (int, int, int, bool, int) Move(int playerRow, int playerCol, string direction, string[,] matrix, string rods, int holes, string vanko, bool electrocuted, int rodesCount, string electrocutedLetter, string cables, string hole)
        {
            (var oldRow, var oldCol) = (playerRow, playerCol);

            (playerRow, playerCol) = GetNewCordinates(playerRow, playerCol, direction);


            if (IsInTheMatrix(playerRow, playerCol, matrix))
            {
                if (matrix[playerRow, playerCol] == cables)
                {
                    electrocuted = true;
                    matrix[oldRow, oldCol] = hole;
                    matrix[playerRow, playerCol] = electrocutedLetter;
                }
                else if(matrix[playerRow, playerCol] == rods)
                {
                    rodesCount++;
                    (playerRow, playerCol) = (oldRow, oldCol);
                    Console.WriteLine("Vanko hit a rod!");
                }
                else if (matrix[playerRow, playerCol] == hole)
                {
                    matrix[oldRow, oldCol] = hole;
                    matrix[playerRow, playerCol] = vanko;
                    Console.WriteLine($"The wall is already destroyed at position [{playerRow}, {playerCol}]!");
                }
                else
                {
                    matrix[playerRow, playerCol] = vanko;
                    matrix[oldRow, oldCol] = hole;
                    holes++;
                }
            }
            else
            {
                (playerRow, playerCol) = (oldRow, oldCol);
            }

            
            return (playerRow, playerCol, holes, electrocuted, rodesCount);
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

        private static bool IsInTheMatrix(int row, int col, string[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
