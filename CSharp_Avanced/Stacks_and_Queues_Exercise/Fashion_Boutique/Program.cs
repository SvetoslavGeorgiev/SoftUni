using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var capacity = int.Parse(Console.ReadLine());

            Stack<int> boxWithClothes = new Stack<int>(input);

            var racks = 1;
            var sumOfQuantitys = 0;

            while (boxWithClothes.Any())
            {

                var currentClothes = boxWithClothes.Pop();

                if ((sumOfQuantitys + currentClothes) <= capacity)
                {
                    sumOfQuantitys += currentClothes;
                }
                else
                {
                    racks++;
                    boxWithClothes.Push(currentClothes);
                    sumOfQuantitys = 0;
                }
            }
            Console.WriteLine(racks);
        }
    }
}
