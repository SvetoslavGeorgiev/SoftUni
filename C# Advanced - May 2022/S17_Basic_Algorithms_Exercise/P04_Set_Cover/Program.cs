namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var universe = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var numberOfsets = int.Parse(Console.ReadLine());
            var sestsOfNumbers = new int[numberOfsets][];

            for (int row = 0; row < sestsOfNumbers.Length; row++)
            {
                var rowValue = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                sestsOfNumbers[row] = new int[rowValue.Length];

                for (int col = 0; col < sestsOfNumbers[row].Length; col++)
                {
                    sestsOfNumbers[row][col] = rowValue[col];
                }
            }

            List<int[]> selectedSets = ChooseSets(sestsOfNumbers.ToList(), universe.ToList());

            Console.WriteLine($"Sets to take ({selectedSets.Count}):");

            foreach (var set in selectedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }

        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {

            var selectedSets = new List<int[]>();

            while (universe.Any())
            {

                var longestSet = sets.OrderByDescending(s => s.Count(x => universe.Contains(x))).FirstOrDefault();

                selectedSets.Add(longestSet);
                sets.Remove(longestSet);

                foreach (var item in longestSet)
                {
                    universe.Remove(item);
                }
            }

            return selectedSets;
        }
    }
}
