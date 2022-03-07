using System;
using System.Collections.Generic;
using System.Linq;

namespace Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfSynonyms = int.Parse(Console.ReadLine());
            var synonyms = new Dictionary<string, string>();

            for (int i = 1; i <= numberOfSynonyms; i++)
            {

                var word = Console.ReadLine();
                var synonym = Console.ReadLine();

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
                    var splitedSynonYms = synonym.Value.Split().ToList();
                    var joinedSynonyms = string.Join(", ", splitedSynonYms);
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
