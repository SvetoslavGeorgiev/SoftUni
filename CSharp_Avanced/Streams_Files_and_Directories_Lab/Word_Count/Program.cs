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
            string inputWords = File.ReadAllText("03. Word Count/words.txt");
            var input = inputWords.Split().ToArray();

            string pattern = @"[a-z]+";
            Regex regex = new Regex(pattern);

            var dict = new Dictionary<string, int>();

            for (int i = 0; i < input.Length; i++)
            {
                dict.Add(input[i], 0);
            }

            using (var reader = new StreamReader("03. Word Count/text.txt"))
            {
                var currentLine = string.Empty;

                while (((currentLine = reader.ReadLine()) != null))
                {

                    var matches = regex.Matches(currentLine.ToLower());

                    foreach (Match word in matches)
                    {
                        for (int i = 0; i < input.Length; i++)
                        {
                            if (word.Value == input[i])
                            {
                                dict[input[i]]++;
                            }
                        }
                    }
                    //var sentence = currentLine.ToLower().Split(new char[] { ',', ' ', '-', '.'  }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    //foreach (var element in sentence)
                    //{
                    //    for (int i = 0; i < input.Length; i++)
                    //    {
                    //        if (element == input[i])
                    //        {
                    //            dict[input[i]]++;
                    //        }
                    //    }
                    //}
                }
            }
            using (var writer = new StreamWriter("Output.txt"))
            {
                foreach (var kvp in dict.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}
