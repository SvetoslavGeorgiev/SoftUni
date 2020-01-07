using System;
using System.Collections.Generic;
using System.Linq;

namespace Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phrase = Console.ReadLine().Split().ToList();

            Random randomize = new Random();
            var result = phrase.Select(x => new { value = x, order = randomize.Next() })
            .OrderBy(x => x.order).Select(x => x.value).ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
