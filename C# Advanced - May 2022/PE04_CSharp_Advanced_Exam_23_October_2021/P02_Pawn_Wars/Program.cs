using System;
using System.Collections.Generic;

namespace P02_Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {

            (var whiteRow, var whiteCol) = (0, 0);
            (var blackRow, var blackCol) = (0, 0);

            var board = new Dictionary<int, string>
            {
                { 0, "a"},
                { 1, "b"},
                { 2, "c"},
                { 3, "d"},
                { 4, "e"},
                { 5, "f"},
                { 6, "g"},
                { 7, "h"},
            };

            for (int r = 0; r < 8; r++)
            {
                var newRow = Console.ReadLine();
                for (int c = 0; c < newRow.Length; c++)
                {
                    if (newRow[c] == 'w')
                    {
                        (whiteRow, whiteCol) = (r, c);
                    }
                    else if (newRow[c] == 'b')
                    {
                        (blackRow, blackCol) = (r, c);
                    }
                }
            }

            var colDiff = Math.Abs(whiteCol - blackCol);
            var rowDiff = Math.Abs(whiteRow - blackRow);

            if (colDiff != 1)
            {
                GetTheQueen(whiteRow, whiteCol, blackRow, blackCol, board);
            }
            else
            {
                if (whiteRow > blackRow)
                {
                    var moves = 0;
                    if (rowDiff % 2 != 0)
                    {
                        moves = rowDiff / 2;
                        blackRow = 8 - (blackRow + moves);

                        Console.WriteLine($"Game over! White capture on {board[blackCol]}{blackRow}.");
                    }
                    else
                    {
                        moves = rowDiff / 2;
                        whiteRow = 8 - (whiteRow - moves);
                        Console.WriteLine($"Game over! Black capture on {board[whiteCol]}{whiteRow}.");
                    }
                }
                else
                {
                    GetTheQueen(whiteRow, whiteCol, blackRow, blackCol, board);
                }
            }
        }

        private static void GetTheQueen(int whiteRow, int whiteCol, int blackRow, int blackCol, Dictionary<int, string> board)
        {
            if (whiteRow <= 7 - blackRow)
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {board[whiteCol]}8.");
            }
            else
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {board[blackCol]}1.");
            }
        }
    }
}
