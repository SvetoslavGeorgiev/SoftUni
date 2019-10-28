using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomb_Numbers2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int[] bombAndPower = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bombNumber = bombAndPower[0];
            int power = bombAndPower[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNumber)
                {
                    if (i - power == 0)
                    {
                        if (i + power <= numbers.Count - 1)
                        {
                            numbers.RemoveRange(0, power * 2 + 1);
                        }
                        else
                        {
                            int diference = (i + power) - (numbers.Count - 1);
                            numbers.RemoveRange(0, (power * 2) + 1 - diference);
                        }
                    }
                    else if (i - power > 0)
                    {
                        if (i + power <= numbers.Count - 1)
                        {
                            numbers.RemoveRange(i - power, power * 2 + 1);
                        }
                        else
                        {
                            int diference = (i + power) - (numbers.Count - 1);
                            numbers.RemoveRange(i - power, (power * 2) + 1 - diference);
                        }
                    }
                    else
                    {
                        int underZero = power - 1;
                        if (i + power <= numbers.Count - 1)
                        {
                            numbers.RemoveRange(0, (power * 2) + 1 - underZero);
                        }
                        else
                        {
                            int diference = (i + power) - (numbers.Count - 1);
                            numbers.RemoveRange(0, (power * 2) + 1 - diference - underZero);
                        }
                    }
                    i = 0;
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
