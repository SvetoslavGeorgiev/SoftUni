using System;
using System.Linq;
using System.Collections.Generic;

namespace Gauss_Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> numbers2 = new List<int>();
            List<int> numbers3 = new List<int>();

            if (numbers.Count % 2 == 0)
            {
                for (int i = 0; i < numbers.Count / 2; i++)
                {
                    numbers2.Add(numbers[i]);
                }
                for (int i = numbers.Count - 1; i >= numbers.Count / 2; i--)
                {
                    numbers3.Add(numbers[i]);
                }
                for (int i = 0; i < numbers2.Count; i++)
                {
                    numbers2[i] += numbers3[i];
                }
            }
            else
            {
                int temp = numbers[(numbers.Count / 2)];

                for (int i = 0; i < numbers.Count / 2; i++)
                {
                    numbers2.Add(numbers[i]);
                }
                for (int i = numbers.Count - 1; i >= numbers.Count / 2; i--)
                {
                    numbers3.Add(numbers[i]);
                }
                for (int i = 0; i < numbers2.Count; i++)
                {
                    numbers2[i] += numbers3[i];
                }

                numbers2.Add(temp);
            }

            Console.WriteLine(string.Join(" ", numbers2));
        }
    }
}
