using System;
using System.Collections.Generic;
using System.Linq;

namespace Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phrases = new List<string> 
            { 
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product." 
            };

            List<string> events = new List<string>
            { 
                "Now I feel good.",
                "I have succeeded with this product.", 
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!" 
            };

            List<string> authors = new List<string>
            {
                "Diana", "Petya", "Stella", "Elena",
                "Katya", "Iva", "Annie", "Eva" 
            };

            List<string> cities = new List<string> 
            { 
                "Burgas", "Sofia", 
                "Plovdiv", "Varna", "Ruse" 
            };

            Random random = new Random();
            var randomPhrase = phrases.Select(x => new { value = x, order = random.Next() })
            .OrderBy(x => x.order).Select(x => x.value).ToList();

            var randomEvent = events.Select(x => new { value = x, order = random.Next() })
            .OrderBy(x => x.order).Select(x => x.value).ToList();

            var randomAuthor = authors.Select(x => new { value = x, order = random.Next() })
            .OrderBy(x => x.order).Select(x => x.value).ToList();

            var randomCity = cities.Select(x => new { value = x, order = random.Next() })
            .OrderBy(x => x.order).Select(x => x.value).ToList();

            Console.WriteLine($"{randomPhrase[0]} {randomEvent[0]} {randomAuthor[0]} – {randomCity[0]}");
        }
    }
}
