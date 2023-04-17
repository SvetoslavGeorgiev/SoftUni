namespace P06_Word_Cruncher
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        static string target;
        static Dictionary<int, List<string>> indexWords;
        static Dictionary<string, int> wordCount;
        static LinkedList<string> wordList;

        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(", ");
            target = Console.ReadLine();

            indexWords = new Dictionary<int, List<string>>();
            wordCount = new Dictionary<string, int>();
            wordList = new LinkedList<string>();

            FillCollections(words);
            GenSolutions(0);
        }

        private static void FillCollections(string[] words)
        {
            foreach (string word in words)
            {
                int index = target.IndexOf(word);
                if (index == -1) continue;

                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                    continue;
                }

                wordCount[word] = 1;
                while (index != -1)
                {
                    if (!indexWords.ContainsKey(index)) indexWords[index] = new List<string>();
                    indexWords[index].Add(word);
                    index = target.IndexOf(word, index + 1);
                }
            }
        }

        private static void GenSolutions(int index)
        {
            if (index == target.Length)
            {
                Console.WriteLine(string.Join(" ", wordList));
                return;
            }

            if (!indexWords.ContainsKey(index)) return;

            foreach (string word in indexWords[index])
            {
                if (wordCount[word] == 0) continue;

                wordCount[word]--;
                wordList.AddLast(word);

                GenSolutions(index + word.Length);

                wordCount[word]++;
                wordList.RemoveLast();
            }
        }
    }
}