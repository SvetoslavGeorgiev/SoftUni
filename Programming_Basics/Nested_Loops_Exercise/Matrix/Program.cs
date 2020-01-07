using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            for (int firstRowFirsNum = a; firstRowFirsNum <= b; firstRowFirsNum++)
            {
                for (int firstRowSecondNum = a; firstRowSecondNum <= b; firstRowSecondNum++)
                {
                    for (int secondRowFirstNum = c; secondRowFirstNum <= d; secondRowFirstNum++)
                    {
                        for (int secondRowSecondNum = c; secondRowSecondNum <= d; secondRowSecondNum++)
                        {
                            if ((firstRowFirsNum + secondRowSecondNum) == (firstRowSecondNum + secondRowFirstNum) 
                                && (firstRowFirsNum != firstRowSecondNum) 
                                && (secondRowFirstNum != secondRowSecondNum))
                            {
                                Console.WriteLine($"{firstRowFirsNum}{firstRowSecondNum}");
                                Console.WriteLine($"{secondRowFirstNum}{secondRowSecondNum}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }
    }
}
