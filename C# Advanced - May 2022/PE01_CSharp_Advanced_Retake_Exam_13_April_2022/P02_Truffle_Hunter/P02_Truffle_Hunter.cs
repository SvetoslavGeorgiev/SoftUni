using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Truffle_Hunter
{
    public class P02_Truffle_Hunter
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            var basket = new Dictionary<string, int>();

            var matrix = new string[size, size];

            var atenTruffles = 0;

            for (int row = 0; row < size; row++)
            {
                var element = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList());

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = element.Dequeue();
                }
            }


            var command = string.Empty;

            while ((command = Console.ReadLine()) != "Stop the hunt")
            {

                var tokens = command.Split(' ');

                if (command.Contains("Collect"))
                {

                    var row = int.Parse(tokens[1]);
                    var col = int.Parse(tokens[2]);

                    var isIt = IsInTheMatrix(row, col, matrix);

                    if (isIt)
                    {
                        if (matrix[row, col] != "-")
                        {
                            if (basket.ContainsKey(matrix[row, col]))
                            {
                                basket[matrix[row, col]]++;
                            }
                            else
                            {
                                basket.Add(matrix[row, col], 1);
                            }
                            matrix[row, col] = "-";
                        }
                    }
                }
                else
                {

                    var row = int.Parse(tokens[1]);
                    var col = int.Parse(tokens[2]);
                    var direction = tokens[3];

                    var isIt = IsInTheMatrix(row, col, matrix);

                    if (isIt)
                    {
                        if (direction == "up")
                        {

                            for (int i = row; i >= 0; i -= 2)
                            {
                                if (matrix[i, col] != "-")
                                {
                                    atenTruffles++;
                                    matrix[i, col] = "-";
                                }
                            }
                        }
                        else if (direction == "down")
                        {
                            for (int i = row; i < size; i += 2)
                            {
                                if (matrix[i, col] != "-")
                                {
                                    atenTruffles++;
                                    matrix[i, col] = "-";
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int i = col; i >= 0; i -= 2)
                            {
                                if (matrix[row, i] != "-")
                                {
                                    atenTruffles++;
                                    matrix[row, i] = "-";
                                }
                            }
                        }
                        else
                        {
                            for (int i = col; i < size; i += 2)
                            {
                                if (matrix[row, i] != "-")
                                {
                                    atenTruffles++;
                                    matrix[row, i] = "-";
                                }
                            }
                        }


                    }
                }
            }
            var black = basket.ContainsKey("B") == false ? "0" : $"{ basket["B"]}";
            var summer = basket.ContainsKey("S") == false ? "0" : $"{ basket["S"]}";
            var white = basket.ContainsKey("W") == false ? "0" : $"{ basket["W"]}";

            Console.WriteLine($"Peter manages to harvest {black} black, {summer} summer, and {white} white truffles.");
            Console.WriteLine($"The wild boar has eaten {atenTruffles} truffles.");
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsInTheMatrix(int row, int col, string[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
