using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordsFilePath = @"../../../words.txt";
            string textFilePath = @"../../../text.txt";
            string outputFilePath = @"../../../Output.txt";

            CalculateWordCounts(wordsFilePath, textFilePath, outputFilePath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            string inputWords = File.ReadAllText(wordsFilePath);
            var input = inputWords.Split().ToArray();

            string pattern = @"[a-z]+";
            Regex regex = new Regex(pattern);

            var dict = new Dictionary<string, int>();

            for (int i = 0; i < input.Length; i++)
            {
                dict.Add(input[i], 0);
            }

            using (var reader = new StreamReader(textFilePath))
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
            using (var writer = new StreamWriter(outputFilePath))
            {
                foreach (var kvp in dict.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }

    }
}
