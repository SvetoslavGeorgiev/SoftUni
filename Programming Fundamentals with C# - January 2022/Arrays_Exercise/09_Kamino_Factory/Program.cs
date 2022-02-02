using System;
using System.Linq;

namespace _09_Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dnaLenght = int.Parse(Console.ReadLine());
            var command = string.Empty;

            var bestDna = new int[dnaLenght];
            var sumOftheDna = 0;
            var counterOfTheSequence = 0;
            var indexOfTheSequence = 0;
            var sampleNumber = 1;
            var currentSampleNumber = 1;


            while ((command = Console.ReadLine()) != "Clone them!")
            {
                var dna = command
                    .Split("!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var currentSumOftheDna = dna.Sum();

                var currentIndexOfTheSequence = 0;
                var bestCurrentCounterOfTheSequence = 0;

                for (int i = 0; i < dnaLenght; i++)
                {
                    var currentCounterOfTheSequence = 0;

                    for (int k = i; k < dnaLenght; k++)
                    {
                        if (dna[i] == 1)
                        {
                            currentCounterOfTheSequence++;
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (currentCounterOfTheSequence > bestCurrentCounterOfTheSequence)
                    {
                        bestCurrentCounterOfTheSequence = currentCounterOfTheSequence;
                        currentIndexOfTheSequence = i - currentCounterOfTheSequence;
                    }
                }
                if (bestCurrentCounterOfTheSequence > counterOfTheSequence)
                {
                    indexOfTheSequence = currentIndexOfTheSequence;
                    counterOfTheSequence = bestCurrentCounterOfTheSequence;
                    sampleNumber = currentSampleNumber;
                    bestDna = dna;
                    sumOftheDna = currentSumOftheDna;
                }
                else if (bestCurrentCounterOfTheSequence == counterOfTheSequence)
                {
                    if (currentIndexOfTheSequence < indexOfTheSequence)
                    {
                        sampleNumber = currentSampleNumber;
                        sumOftheDna = currentSumOftheDna;
                        bestDna = dna;
                        indexOfTheSequence = currentIndexOfTheSequence;
                    }
                    else if (currentIndexOfTheSequence == indexOfTheSequence)
                    {
                        if (currentSumOftheDna > sumOftheDna)
                        {
                            sampleNumber = currentSampleNumber;
                            sumOftheDna = currentSumOftheDna;
                            bestDna = dna;
                        }
                    }
                }
                currentSampleNumber++;
            }
            Console.WriteLine($"Best DNA sample {sampleNumber} with sum: {sumOftheDna}.");
            Console.WriteLine(string.Join(" ", bestDna));
        }
    }
}
