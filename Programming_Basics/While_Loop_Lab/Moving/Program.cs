using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int cubicsMetters = width * lenght * height;

            int sumCubics = 0;

            string finishCommand = Console.ReadLine();

            while (finishCommand != "Done")
            {
                int currentCubic = int.Parse(finishCommand);
                sumCubics += currentCubic;

                if (cubicsMetters < sumCubics)
                {
                    int neededCubics = sumCubics - cubicsMetters;
                    Console.WriteLine($"No more free space! You need " +
                        $"{neededCubics} Cubic meters more.");
                    break;
                }
                finishCommand = Console.ReadLine();
            }
            if (finishCommand == "Done")
            {
                int leftCubics = cubicsMetters - sumCubics;
                Console.WriteLine($"{leftCubics} Cubic meters left.");
            }
        }
    }
}
