using System;
using System.Collections.Generic;

namespace _01_Advertisement_Message
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var phrases = new List<string>() 
            { 
                "Excellent product.", 
                "Such a great product.", 
                "I always use that product.", 
                "Best product of its category.", 
                "Exceptional product.", 
                "I can’t live without this product." 
            };

            var events = new List<string>() 
            { 
                "Now I feel good.", 
                "I have succeeded with this product.", 
                "Makes miracles. I am happy of the results!", 
                "I cannot believe but now I feel awesome.", 
                "Try it yourself, I am very satisfied.", 
                "I feel great!" 
            };

            var authors = new List<string>() 
            { 
                "Diana", "Petya", "Stella", "Elena", 
                "Katya", "Iva", "Annie", "Eva" 
            };

            var cities = new List<string>() 
            { 
                "Burgas", "Sofia", 
                "Plovdiv", "Varna", 
                "Ruse" 
            };

            var messagesToPrint = int.Parse(Console.ReadLine());

            PrintFakeMessage(authors, phrases, messagesToPrint, cities, events);
        
        }

        private static void PrintFakeMessage(List<string> authors, List<string> phrases, int messagesToPrint, List<string> cities, List<string> events)
        {
            for (int i = 0; i < messagesToPrint; i++)
            { 

                Console.WriteLine($"{phrases[GetRandomIndex(phrases)]} {events[GetRandomIndex(events)]} {authors[GetRandomIndex(authors)]} – {cities[GetRandomIndex(cities)]}.");

            }
        }

        private static int GetRandomIndex(List<string> list)
        {
            var rnd = new Random();
            var randomIndex = rnd.Next(list.Count - 1);

            return randomIndex;

        }
    }
}
