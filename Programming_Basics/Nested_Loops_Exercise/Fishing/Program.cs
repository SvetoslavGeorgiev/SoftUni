using System;

namespace TestFishes
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = int.Parse(Console.ReadLine());
            string name = string.Empty;
            double weight = 0;
            int counter = 0;
            double sum = 0;
            double fishPrice = 0;
            int fishes = 0;

            for (int i = 1; i <= limit; i++)
            {
                name = Console.ReadLine();
                if (name == "Stop")
                {
                    break;
                }
                fishes++;
                weight = double.Parse(Console.ReadLine());
                fishPrice = 0;

                for (int j = 0; j < name.Length; j++)
                {
                    char symbol = name[j];
                    fishPrice += symbol;
                    //Console.WriteLine("FP="+fishPrice);

                }

                counter++;
                if (counter == 3)
                {
                    sum += (fishPrice / weight);
                    counter = 0;
                }
                else if (counter < 3)
                {
                    sum -= (fishPrice / weight);
                }
            }

            if (name == "Stop")
            {
                if (sum < 0)
                {
                    Console.WriteLine($"Lyubo lost {Math.Abs(sum):f2} leva today.");
                }
                else
                {
                    Console.WriteLine($"Lyubo's profit from {fishes} fishes is {sum:f2} leva.");
                }
            }
            else
            {
                Console.WriteLine("Lyubo fulfilled the quota!");
                if (sum < 0)
                {
                    Console.WriteLine($"Lyubo lost {Math.Abs(sum):f2} leva today.");
                }
                else
                {
                    Console.WriteLine($"Lyubo's profit from {fishes} fishes is {sum:f2} leva.");
                }
            }
        }
    }
}