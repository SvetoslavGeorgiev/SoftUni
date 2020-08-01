using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<string>();

            using (var reader = new StreamReader("words.txt"))
            {
                var line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    input.Add(line);
                }
            }


            string pattern = @"[a-z]+";
            Regex regex = new Regex(pattern);

            var dict = new Dictionary<string, int>();

            for (int i = 0; i < input.Count; i++)
            {
                dict.Add(input[i], 0);
            }

            using (var reader = new StreamReader("text.txt"))
            {
                var currentLine = string.Empty;

                while (((currentLine = reader.ReadLine()) != null))
                {

                    var matches = regex.Matches(currentLine.ToLower());

                    foreach (Match word in matches)
                    {
                        for (int i = 0; i < input.Count; i++)
                        {
                            if (word.Value == input[i])
                            {
                                dict[input[i]]++;
                            }
                        }
                    }
                }
            }
            using (var writer = new StreamWriter("actualResult.txt"))
            {
                foreach (var kvp in dict.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }

            var actualResult = File.ReadAllText("actualResult.txt");
            var expectedResult = File.ReadAllText("expectedResult.txt");
            using (var writer = new StreamWriter("Outout.txt"))
            {
                if (actualResult == expectedResult)
                {
                    writer.Write("True");
                }
                else
                {
                    writer.Write("False");
                }
            }
        }
    }
}
