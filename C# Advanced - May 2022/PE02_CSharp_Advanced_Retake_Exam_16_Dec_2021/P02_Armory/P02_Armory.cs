using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_Armory
{
    public class P02_Armory
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            var swords = new Dictionary<string, int>();

            var matrix = new string[size, size];

            var oficerPositionRow = 0;
            var oficerPositionCol = 0;


            var sum = 0;

            for (int row = 0; row < size; row++)
            {
                var element = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = element[col].ToString();
                    if (matrix[row, col] == "A")
                    {
                        oficerPositionRow = row;
                        oficerPositionCol = col;
                    }
                }
            }

            var isItInTheMatrix = false;

            while (true)
            {
                var move = Console.ReadLine();
                matrix[oficerPositionRow, oficerPositionCol] = "-";
                if (move == "up")
                {
                    isItInTheMatrix = IsInTheMatrix(oficerPositionRow - 1, oficerPositionCol, matrix);

                    if (isItInTheMatrix)
                    {
                        oficerPositionRow--;
                        if (matrix[oficerPositionRow, oficerPositionCol] != "-")
                        {

                            if (matrix[oficerPositionRow, oficerPositionCol] == "M")
                            {
                                matrix[oficerPositionRow, oficerPositionCol] = "-";

                                for (int row = 0; row < matrix.GetLength(0); row++)
                                {
                                    for (int col = 0; col < matrix.GetLength(1); col++)
                                    {
                                        if (matrix[row, col] == "M")
                                        {
                                            oficerPositionRow = row;
                                            oficerPositionCol = col;
                                            matrix[row, col] = "A";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                sum += int.Parse(matrix[oficerPositionRow, oficerPositionCol]);
                                matrix[oficerPositionRow, oficerPositionCol] = "A";
                                if (sum >= 65)
                                {
                                    break;
                                }
                            }


                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else if (move == "down")
                {
                    isItInTheMatrix = IsInTheMatrix(oficerPositionRow + 1, oficerPositionCol, matrix);

                    if (isItInTheMatrix)
                    {
                        oficerPositionRow++;
                        if (matrix[oficerPositionRow, oficerPositionCol] != "-")
                        {

                            if (matrix[oficerPositionRow, oficerPositionCol] == "M")
                            {
                                matrix[oficerPositionRow, oficerPositionCol] = "-";

                                for (int row = 0; row < matrix.GetLength(0); row++)
                                {
                                    for (int col = 0; col < matrix.GetLength(1); col++)
                                    {
                                        if (matrix[row, col] == "M")
                                        {
                                            oficerPositionRow = row;
                                            oficerPositionCol = col;
                                            matrix[row, col] = "A";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                sum += int.Parse(matrix[oficerPositionRow, oficerPositionCol]);
                                matrix[oficerPositionRow, oficerPositionCol] = "A";
                                if (sum >= 65)
                                {
                                    break;
                                }
                            }


                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else if (move == "left")
                {

                    isItInTheMatrix = IsInTheMatrix(oficerPositionRow, oficerPositionCol - 1, matrix);

                    if (isItInTheMatrix)
                    {
                        oficerPositionCol--;
                        if (matrix[oficerPositionRow, oficerPositionCol] != "-")
                        {

                            if (matrix[oficerPositionRow, oficerPositionCol] == "M")
                            {
                                matrix[oficerPositionRow, oficerPositionCol] = "-";

                                for (int row = 0; row < matrix.GetLength(0); row++)
                                {
                                    for (int col = 0; col < matrix.GetLength(1); col++)
                                    {
                                        if (matrix[row, col] == "M")
                                        {
                                            oficerPositionRow = row;
                                            oficerPositionCol = col;
                                            matrix[row, col] = "A";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                sum += int.Parse(matrix[oficerPositionRow, oficerPositionCol]);
                                matrix[oficerPositionRow, oficerPositionCol] = "A";
                                if (sum >= 65)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    isItInTheMatrix = IsInTheMatrix(oficerPositionRow, oficerPositionCol + 1, matrix);

                    if (isItInTheMatrix)
                    {
                        oficerPositionCol++;
                        if (matrix[oficerPositionRow, oficerPositionCol] != "-")
                        {

                            if (matrix[oficerPositionRow, oficerPositionCol] == "M")
                            {
                                matrix[oficerPositionRow, oficerPositionCol] = "-";

                                for (int row = 0; row < matrix.GetLength(0); row++)
                                {
                                    for (int col = 0; col < matrix.GetLength(1); col++)
                                    {
                                        if (matrix[row, col] == "M")
                                        {
                                            oficerPositionRow = row;
                                            oficerPositionCol = col;
                                            matrix[row, col] = "A";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                sum += int.Parse(matrix[oficerPositionRow, oficerPositionCol]);
                                matrix[oficerPositionRow, oficerPositionCol] = "A";
                                if (sum >= 65)
                                {
                                    break;
                                }
                            }


                        }
                    }
                    else
                    {
                        break;
                    }

                }



            }
            if (isItInTheMatrix)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            else
            {
                Console.WriteLine("I do not need more swords!");
            }
            Console.WriteLine($"The king paid {sum} gold coins.");

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

        private static bool IsInTheMatrix(int row, int col, string[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
