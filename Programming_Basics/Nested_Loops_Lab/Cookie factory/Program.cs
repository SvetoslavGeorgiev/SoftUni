using System;

namespace Cookie_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int batchesCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= batchesCount; i++)
            {
                bool containsEggs = false;
                bool containesSugar = false;
                bool containesFlour = false;

                string ingradient = string.Empty;

                while (true)
                {
                    ingradient = Console.ReadLine();
                    if (ingradient == "eggs")
                    {
                        containsEggs = true;
                    }
                    else if (ingradient == "flour")
                    {
                        containesFlour = true;
                    }
                    else if (ingradient == "sugar")
                    {
                        containesSugar = true;
                    }
                    else if (ingradient == "Bake!")
                    {
                        if (containesFlour && containesSugar && containsEggs)
                        {
                            Console.WriteLine($"Baking batch number {i}...");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The batter should contain flour, eggs and sugar!");
                        }
                    }
                }
               
            }
        }
    }
}
