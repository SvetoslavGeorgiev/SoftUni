using System;
using System.Linq;
 
namespace Kamino_Factory
{
    class Program
    {
        static void Main()
        {
            int longDna = int.Parse(Console.ReadLine());
            string commond = Console.ReadLine();

            int[] bestDnk = new int[longDna];
            int bestSumDnk = 0;
            int bestLenghtOne = 0;
            int bestFirstIndexOne = 0;
            int bestRow = 1;
            int currentRow = 1;

            while (commond != "Clone them!")
            {
                int[] currentDnk = commond
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currentSumDnk = currentDnk.Sum();

                int bestCurrentLengthOne = 0;
                int currentFirstIndexOne = 0;

                for (int i = 0; i < currentDnk.Length; i++)
                {
                    int currentLenghOne = 0;

                    for (int j = i; j < currentDnk.Length; j++)
                    {
                        if (currentDnk[i] == 1)
                        {
                            currentLenghOne++;
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (currentLenghOne > bestCurrentLengthOne)
                    {
                        bestCurrentLengthOne = currentLenghOne;
                        currentFirstIndexOne = i - currentLenghOne;
                    }
                }

                if (bestCurrentLengthOne > bestLenghtOne)
                {
                    bestLenghtOne = bestCurrentLengthOne;
                    bestRow = currentRow;
                    bestSumDnk = currentSumDnk;
                    bestDnk = currentDnk;
                    bestFirstIndexOne = currentFirstIndexOne;
                }
                else if (bestCurrentLengthOne == bestLenghtOne)
                {
                    if (currentFirstIndexOne < bestFirstIndexOne)
                    {
                        bestRow = currentRow;
                        bestSumDnk = currentSumDnk;
                        bestDnk = currentDnk;
                        bestFirstIndexOne = currentFirstIndexOne;
                    }
                    else if (currentFirstIndexOne == bestFirstIndexOne)
                    {
                        if (currentSumDnk > bestSumDnk)
                        {
                            bestRow = currentRow;
                            bestSumDnk = currentSumDnk;
                            bestDnk = currentDnk;
                        }

                    }
                }
                currentRow++;
                commond = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestRow} with sum: {bestSumDnk}.");
            Console.WriteLine(string.Join(" ", bestDnk));
        }
    }
}