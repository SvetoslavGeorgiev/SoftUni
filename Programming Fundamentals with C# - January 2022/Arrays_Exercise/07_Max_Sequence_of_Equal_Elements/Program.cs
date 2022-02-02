using System;
using System.Linq;

namespace _07_Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            var counterOfTheSequence = 0;
            var numberOfTheSequence = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                var currentCounterOfTheSequence = 1;
                var currentNumberOfTheSequence = arr[i];

                for (int k = i + 1; k < arr.Length; k++)
                {
                    if (arr[i] == arr[k])
                    {
                        currentCounterOfTheSequence++;
                        currentNumberOfTheSequence = arr[i];
                    }
                    else
                    {
                        break;
                    }
                }
                if (counterOfTheSequence < currentCounterOfTheSequence)
                {
                    counterOfTheSequence = currentCounterOfTheSequence;
                    numberOfTheSequence = currentNumberOfTheSequence;
                }
            }
            for (int i = 0; i < counterOfTheSequence; i++)
            {
                Console.Write($"{numberOfTheSequence} ");
            }
        }
    }
}
