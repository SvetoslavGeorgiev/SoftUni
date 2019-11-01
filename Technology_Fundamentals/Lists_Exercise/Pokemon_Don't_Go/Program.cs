using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int sumOfRemovedIndexes = 0;
            List<int> increaceOrDecreace = new List<int>();
            int index = int.Parse(Console.ReadLine());
            

            while (sequence.Count > 0)
            {
                int temp = 0;

                
                if (index >= sequence.Count)
                {
                    temp = sequence[sequence.Count - 1];
                    sumOfRemovedIndexes += temp;
                    sequence.RemoveAt(sequence.Count - 1);
                    sequence.Add(sequence[0]);
                    //sequence[sequence.Count - 1] = sequence[0];
                    increaceOrDecreace = IncreaceOrDecreace(sequence, temp);
                    
                }
                else if (index < 0)
                {
                    temp = sequence[0];
                    sumOfRemovedIndexes += temp;
                    sequence.RemoveAt(0);
                    sequence.Insert(0, sequence[sequence.Count - 1]);
                    //sequence[0] = sequence[sequence.Count - 1];
                    increaceOrDecreace = IncreaceOrDecreace(sequence, temp);

                }
                else
                {
                    temp = sequence[index];
                    sumOfRemovedIndexes += temp;
                    sequence.RemoveAt(index);
                    increaceOrDecreace = IncreaceOrDecreace(sequence, temp);
                    
                }
                
                if (sequence.Count == 0)
                {
                    break;
                }
                else
                {
                    index = int.Parse(Console.ReadLine());
                }
                
            }
            Console.WriteLine(sumOfRemovedIndexes);
        }

        private static List<int> IncreaceOrDecreace(List<int> sequence, int temp)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] <= temp)
                {
                    sequence[i] += temp;
                }
                else
                {
                    sequence[i] -= temp;

                }
            }
            return sequence;
        }
    }
}
