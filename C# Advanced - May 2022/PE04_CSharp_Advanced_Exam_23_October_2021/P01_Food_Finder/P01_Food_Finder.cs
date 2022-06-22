using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Food_Finder
{
    public class P01_Food_Finder
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var vowels = new Queue<string>(input);

            var input2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var consonants = new Stack<string>(input2);


            var words = new Dictionary<string, List<string>>()
            {
                {"pear", new List<string>{"p", "e", "a", "r"}},
                {"flour", new List<string>{"f","l", "o", "u", "r"}},
                {"pork", new List<string>{"p", "o", "r", "k"}},
                {"olive", new List<string>{"o", "l", "i", "v", "e"}}
            };


            while (consonants.Any())
            {

                var vowel = vowels.Dequeue();
                var consonant = consonants.Pop();

                

                foreach (var word in words)
                {
                    if (word.Value.Contains(vowel))
                    {
                        word.Value.Remove(vowel);
                    }
                    if (word.Value.Contains(consonant))
                    {
                        word.Value.Remove(consonant);
                    }
                }

                vowels.Enqueue(vowel);
            }


            var filtered = words.Where(x => x.Value.Count == 0).ToDictionary(x => x.Key, x => x.Value);
            //List<KeyValuePair<string, List<string>>> filtered = words.Where(x => x.Value.Count == 0).ToList(); //=> List<KeyValuePair<string, List<string>>>

            Console.WriteLine($"Words found: {filtered.Count()}");
            foreach (var word in filtered)
            {
                Console.WriteLine(word.Key);
            }
        }
    }
}
