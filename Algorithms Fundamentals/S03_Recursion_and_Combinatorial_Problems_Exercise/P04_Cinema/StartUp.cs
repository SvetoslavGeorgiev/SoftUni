namespace P04_Cinema
{
    using System.Collections.Generic;
    using System.Text;
    using System;
    using System.Linq;

    internal class StartUp
    {
        static List<string> names;
        static string[] positions;
        static bool[] locked;

        static void Main(string[] args)
        {
            names = Console.ReadLine().Split(", ").ToList();
            positions = new string[names.Count];
            locked = new bool[names.Count];

            string input = Console.ReadLine();
            while (input != "generate")
            {
                string[] data = input.Split(" - ");
                string name = data[0];
                int place = int.Parse(data[1]) - 1;

                positions[place] = name;
                locked[place] = true;
                names.Remove(name);

                input = Console.ReadLine();
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= names.Count)
            {
                Print();
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < names.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Print()
        {
            int ind = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < positions.Length; i++)
            {
                if (locked[i]) sb.Append($"{positions[i]} ");
                else sb.Append($"{names[ind++]} ");
            }

            Console.WriteLine(sb.ToString().Trim());
        }

        private static void Swap(int first, int second) =>
            (names[first], names[second]) = (names[second], names[first]);
    }
}