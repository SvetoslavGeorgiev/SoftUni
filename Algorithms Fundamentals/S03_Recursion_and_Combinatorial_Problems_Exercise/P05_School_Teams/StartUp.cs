namespace P05_School_Teams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] girls = Console.ReadLine().Split(", ");
            string[] girlsCombo = new string[3];
            List<string[]> girlsCombos = new List<string[]>();
            GenCombos(0, 0, girls, girlsCombo, girlsCombos);

            string[] boys = Console.ReadLine().Split(", ");
            string[] boysCombo = new string[2];
            List<string[]> boysCombos = new List<string[]>();
            GenCombos(0, 0, boys, boysCombo, boysCombos);

            foreach (string[] girl in girlsCombos)
            {
                foreach (string[] boy in boysCombos)
                {
                    Console.WriteLine($"{string.Join(", ", girl)}, {string.Join(", ", boy)}");
                }
            }
        }

        private static void GenCombos(int index, int start, string[] input, string[] combo, List<string[]> list)
        {
            if (index >= combo.Length)
            {
                list.Add(combo.ToArray());
                return;
            }

            for (int i = start; i < input.Length; i++)
            {
                combo[index] = input[i];
                GenCombos(index + 1, i + 1, input, combo, list);
            }
        }
    }
}