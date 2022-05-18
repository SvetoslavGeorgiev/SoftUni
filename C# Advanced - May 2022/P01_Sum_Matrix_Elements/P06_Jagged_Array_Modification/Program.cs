using System;
using System.Linq;

namespace P06_Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            int[][] arr = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                var currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                arr[i] = currentRow;
            }

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                var commandArr = command.ToLower().Split().ToArray();

                if (int.Parse(commandArr[1]) >= 0 &&
                    int.Parse(commandArr[2]) >= 0 &&
                    int.Parse(commandArr[1]) < rows &&
                    int.Parse(commandArr[2]) < arr[int.Parse(commandArr[1])].Length)
                {
                    if (commandArr[0] == "add")
                    {
                        arr[int.Parse(commandArr[1])][int.Parse(commandArr[2])] += int.Parse(commandArr[3]);
                    }
                    else if (commandArr[0] == "subtract")
                    {
                        arr[int.Parse(commandArr[1])][int.Parse(commandArr[2])] -= int.Parse(commandArr[3]);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < arr[row].Length; col++)
                {
                    Console.Write($"{arr[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
