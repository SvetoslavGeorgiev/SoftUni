using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_Take_Skip_Rope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var encrypted = Console.ReadLine()
                .ToCharArray()
                .ToList();

            var digitCounter = 0;

            var numberOfCharsToTake = new List<int>();
            var numberOfCharsToSkip = new List<int>();

            var decrypted = new StringBuilder();

            for (int i = 0; i < encrypted.Count; i++)
            {
                if (char.IsDigit(encrypted[i]))
                {
                    if (digitCounter % 2 == 0)
                    {
                        numberOfCharsToTake.Add(int.Parse(encrypted[i].ToString()));
                    }
                    else 
                    {
                        numberOfCharsToSkip.Add(int.Parse(encrypted[i].ToString()));
                    }
                    digitCounter++;
                    encrypted.RemoveAt(i);
                    i--;
                }
            }
            var skipCounter = - 1;
            for (int i = 0; i < encrypted.Count; i+=numberOfCharsToSkip[skipCounter])
            {
                while (numberOfCharsToTake.Any())
                {
                    var curentCharsToTake = numberOfCharsToTake[0];
                    numberOfCharsToTake.RemoveAt(0);
                    var end = Math.Min(curentCharsToTake + i, encrypted.Count);
                    for (int k = i; k < end; k++)
                    {
                        decrypted.Append(encrypted[k]);
                    }
                    i += curentCharsToTake;
                    break;
                }
                if (!numberOfCharsToTake.Any())
                {
                    break;
                }
                skipCounter++;
            }
            Console.WriteLine(decrypted);
        }
    }
}