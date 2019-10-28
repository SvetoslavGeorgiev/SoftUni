using System;
using System.Linq;

namespace Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int counterOfSequence = 0;
            int element = 0;
            int currentCounter = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    currentCounter++;
                    if (currentCounter > counterOfSequence)
                    {
                        counterOfSequence = currentCounter;
                        element = arr[i];
                    }
                }
                else
                {
                    currentCounter = 0;
                }
            }
            for (int i = 0; i <= counterOfSequence; i++)
            {
                Console.Write($"{element} ");
            }
            //int[] numbers = Console.ReadLine()
            //               .Split()
            //               .Select(int.Parse)
            //               .ToArray();
            //int counter = 0;
            //int winningCounter = 0;
            //int index = 0;
            //string number = string.Empty;

            //for (int i = 0; i < numbers.Length - 1; i++)
            //{
            //    if (numbers[i] == numbers[i + 1])
            //    {
            //        counter++;
            //        if (counter > winningCounter)
            //        {
            //            winningCounter = counter;
            //            index = i;
            //            number = numbers[i].ToString();
            //        }
            //    }
            //    else
            //    {
            //        counter = 0;
            //    }
            //}
            //for (int i = 0; i <= winningCounter; i++)
            //{
            //    Console.Write(number + " ");
            //}
        }
    }
}
