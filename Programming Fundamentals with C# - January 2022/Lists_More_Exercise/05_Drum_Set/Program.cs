using System;
using System.Linq;

namespace _05_Drum_Set
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var savigns = double.Parse(Console.ReadLine());

            var drumsSet = Console.ReadLine().Split().Select(int.Parse).ToList();

            var command = string.Empty;

            var arr = drumsSet.ToArray();


            while ((command = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                var power = int.Parse(command);

                for (int i = 0; i < drumsSet.Count; i++)
                {
                    drumsSet[i] -= power;
                    if (drumsSet[i] != -1001 && drumsSet[i] <= 0 && savigns >= arr[i] * 3)
                    {
                        drumsSet[i] = arr[i];

                        savigns -= arr[i] * 3;
                    }
                    else if(drumsSet[i] != -1001 && drumsSet[i] <= 0 && savigns < arr[i] * 3)
                    {
                        drumsSet[i] = -1001;
                    }
                }
            }
            var output = drumsSet.Where(x => x != -1001).ToList();
            Console.WriteLine(string.Join(" ", output));
            Console.WriteLine($"Gabsy has {savigns:F2}lv.");
        }
    }
}