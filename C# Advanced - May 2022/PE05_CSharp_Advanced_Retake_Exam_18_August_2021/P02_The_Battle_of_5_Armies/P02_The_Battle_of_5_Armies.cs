using System;
using System.Linq;

namespace P02_The_Battle_of_5_Armies
{
    public class P02_The_Battle_of_5_Armies
    {
        static void Main()
        {
            (var player, var orcs, var mordor, var empty, var dead) = ("A", "O", "M", "-", "X");
            (var playerRow, var playerCol, var mordorRow, var mordorCol) = (0, 0, 0, 0);


            var myArmyArmor = int.Parse(Console.ReadLine());
            var rows = int.Parse(Console.ReadLine());

            var middleWorld = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray().Select(x => x.ToString()).ToArray();

                middleWorld[row] = currentRow;

                for (int col = 0; col < middleWorld[row].Length; col++)
                {
                    if (middleWorld[row][col] == player)
                    {
                        (playerRow, playerCol) = (row, col);
                    }
                    else if (middleWorld[row][col] == mordor)
                    {
                        (mordorRow, mordorCol) = (row, col);
                    }
                }

            }

            while (myArmyArmor > 0 && middleWorld[playerRow][playerCol] != mordor)
            {
                var tokens = Console.ReadLine().Split();
                (var direction, var orcRow, var orcCol) = (tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2]));


                middleWorld[orcRow][orcCol] = orcs;

                myArmyArmor--;

                (playerRow, playerCol, myArmyArmor) = Move(playerRow, playerCol, direction, middleWorld, orcs, myArmyArmor, player, empty);

            }

            if (myArmyArmor <= 0 && middleWorld[playerRow][playerCol] != mordor)
            {
                middleWorld[playerRow][playerCol] = dead;
                Console.WriteLine($"The army was defeated at {playerRow};{playerCol}.");
            }
            else
            {
                middleWorld[mordorRow][mordorCol] = empty;
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {myArmyArmor}");
            }
            PrintMatrix(middleWorld);






            //foreach (var row in middleWorld)
            //{
            //    Console.WriteLine(string.Join(" ", row));
            //}

        }
        private static void PrintMatrix(string[][] beach)
        {
            for (int row = 0; row < beach.GetLength(0); row++)
            {
                Console.WriteLine(string.Join("", beach[row]));
            }
        }

        private static (int, int, int) Move(int playerRow, int playerCol, string direction, string[][] middleWorld, string orcs, int myArmyArmor, string player, string empty)
        {
            (var oldRow, var oldCol) = (playerRow, playerCol);

            (playerRow, playerCol) = GetNewCordinates(playerRow, playerCol, direction);

            if (IsInTheMatrix(playerRow, playerCol, middleWorld))
            {
                middleWorld[oldRow][oldCol] = empty;
                if (middleWorld[playerRow][playerCol] == orcs)
                {
                    myArmyArmor -= 2;
                    middleWorld[playerRow][playerCol] = player;
                }
            }
            else
            {
                (playerRow, playerCol) = (oldRow, oldCol);
            }

            return (playerRow, playerCol, myArmyArmor);
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
