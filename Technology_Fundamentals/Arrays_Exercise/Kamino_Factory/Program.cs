using System;
using System.Linq;

namespace Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthOfDNA = int.Parse(Console.ReadLine());
            

            int counterOfSequence = -1;
            int index = 1;
            int moastOneses = 0;

            int bestSample = 0;
            int sampleCounter = 1;

            int[] savedDna = new int[lengthOfDNA];
            string dnaCommand = Console.ReadLine();

            while (dnaCommand != "Clone them!")
            {

                
                int[] dna = dnaCommand
                     .Split('!', StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();
                int currentCounter = 0;
                int counterOfOneses = 0;
                int currentIndex = -1;

                int currentCounter2 = 0;
                for (int i = 0; i < lengthOfDNA; i++)
                {
                    if (dna[i] == 1)
                    {
                        currentCounter2++;
                        counterOfOneses++;
                        if (currentCounter2 >= currentCounter)
                        {

                            currentCounter = currentCounter2;
                            currentIndex = i - currentCounter;

                        }
                    }
                    else
                    {
                        
                        currentCounter2 = 0;
                    }
                }
                if (currentCounter > counterOfSequence)
                {
                    index = currentIndex;
                    counterOfSequence = currentCounter;
                    moastOneses = counterOfOneses;
                    savedDna = dna;
                    bestSample = sampleCounter;
                    
                }
                else if (currentCounter == counterOfSequence && index > currentIndex)
                {
                    index = currentIndex;
                    moastOneses = counterOfOneses;
                    savedDna = dna;
                    bestSample = sampleCounter;
                }
                else if (currentCounter == counterOfSequence && index == currentIndex && moastOneses < counterOfOneses)
                {
                    moastOneses = counterOfOneses;
                    savedDna = dna;
                    bestSample = sampleCounter;
                }

                sampleCounter++;
                dnaCommand = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSample} with sum: {moastOneses}.");
            Console.WriteLine(string.Join(" ", savedDna));
        }
    }
}
