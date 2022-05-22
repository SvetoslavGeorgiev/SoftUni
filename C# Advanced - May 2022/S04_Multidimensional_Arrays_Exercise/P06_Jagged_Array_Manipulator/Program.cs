using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rowsNumbers = int.Parse(Console.ReadLine());

            var jaggedArray = new int[rowsNumbers][];

            for (int i = 0; i < rowsNumbers; i++)
            {
                var currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[i] = currentRow;
            }

            for (int i = 0; i < rowsNumbers - 1; i++)
            {
                if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
                {
                    jaggedArray[i] = jaggedArray[i].Select(x => x * 2).ToArray();
                    jaggedArray[i + 1] = jaggedArray[i + 1].Select(x => x * 2).ToArray();




                    //var jaggedRow = jaggedArray[i];
                    //for (int k = 0; k < jaggedRow.Length; k++)
                    //{
                    //    jaggedRow[k] = jaggedRow[k] * 2;
                    //}
                    //jaggedArray[i] = jaggedRow;

                    //jaggedRow = jaggedArray[i + 1];
                    //for (int k = 0; k < jaggedArray[i + 1].Length; k++)
                    //{
                    //    jaggedRow[k] = jaggedRow[k] * 2;
                    //}
                    //jaggedArray[i + 1] = jaggedRow;
                }
                else
                {
                    jaggedArray[i] = jaggedArray[i].Select(x => x / 2).ToArray();
                    jaggedArray[i + 1] = jaggedArray[i + 1].Select(x => x / 2).ToArray();





                    //var jaggedRow = jaggedArray[i];
                    //for (int k = 0; k < jaggedRow.Length; k++)
                    //{
                    //    jaggedRow[k] = jaggedRow[k] / 2;
                    //}
                    //jaggedArray[i] = jaggedRow;

                    //jaggedRow = jaggedArray[i + 1];
                    //for (int k = 0; k < jaggedArray[i + 1].Length; k++)
                    //{
                    //    jaggedRow[k] = jaggedRow[k] / 2;
                    //}
                    //jaggedArray[i + 1] = jaggedRow;
                }
            }




            var command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {

                var commandArr = command.ToLower()
                    .Split()
                    .ToArray();

                if (int.Parse(commandArr[1]) >= 0 &&
                    int.Parse(commandArr[2]) >= 0 &&
                    int.Parse(commandArr[1]) < rowsNumbers &&
                    int.Parse(commandArr[2]) < jaggedArray[int.Parse(commandArr[1])].Length)
                {
                    if (commandArr[0] == "add")
                    {
                        jaggedArray[int.Parse(commandArr[1])][int.Parse(commandArr[2])] += int.Parse(commandArr[3]);
                    }
                    else if (commandArr[0] == "subtract")
                    {
                        jaggedArray[int.Parse(commandArr[1])][int.Parse(commandArr[2])] -= int.Parse(commandArr[3]);
                    }
                }
            }

            for (int row = 0; row < rowsNumbers; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
