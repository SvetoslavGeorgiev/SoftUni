using System;

namespace _10_Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lostGames = int.Parse(Console.ReadLine());
            var headsetPrice = decimal.Parse(Console.ReadLine());
            var mousePrice = decimal.Parse(Console.ReadLine());
            var keyboardPrice = decimal.Parse(Console.ReadLine());
            var displayPrice = decimal.Parse(Console.ReadLine());

            var trashedHeadsetsCount = 0;
            var trashedMousesCount = 0;
            var trashedKeyboardCount = 0;
            var trashedDisplayCount = 0;
            var counterForDisplay = 0;

            for (int i = 1; i <= lostGames; i++)
            {

                if (i % 2 == 0)
                {
                    trashedHeadsetsCount++;
                }
                if (i % 3 == 0)
                {
                    trashedMousesCount++;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    trashedKeyboardCount++;
                    counterForDisplay++;
                }
                if (counterForDisplay == 2)
                {
                    trashedDisplayCount++;
                    counterForDisplay = 0;
                }
            }

            var totalExpenses = (trashedDisplayCount * displayPrice) + (trashedHeadsetsCount * headsetPrice) + (trashedKeyboardCount * keyboardPrice) + (trashedMousesCount * mousePrice);

            Console.WriteLine($"Rage expenses: {totalExpenses:F2} lv.");


        }
    }
}
