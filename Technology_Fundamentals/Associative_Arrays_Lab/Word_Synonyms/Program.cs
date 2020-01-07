using System;
using System.Collections.Generic;
using System.Linq;

namespace Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSynonyms = int.Parse(Console.ReadLine());
            Dictionary<string, string> synonyms = new Dictionary<string, string>();

            for (int i = 1; i <= numberOfSynonyms; i++)
            {
                
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (synonyms.ContainsKey(word))
                {
                    synonyms[word] += $" {synonym}";
                }
                else
                {
                    synonyms.Add(word, synonym);
                }
            }

            foreach (var synonym in synonyms)
            {
                if (synonym.Value.Contains(' '))
                {
                    List<string> splitedSynonYms = synonym.Value.Split().ToList();
                    string joinedSynonyms = string.Join(", ", splitedSynonYms);
                    Console.WriteLine($"{synonym.Key} - {joinedSynonyms}");
                }
                else
                {
                    Console.WriteLine($"{synonym.Key} - {synonym.Value}");
                }
            }
        }
    }
}
