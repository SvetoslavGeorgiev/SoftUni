using System;

namespace Foreign_Languages
{
    class Program
    {
        static void Main(string[] args)
        {
            var contry = Console.ReadLine();

            string language = string.Empty;

            switch (contry)
            {
                case "England":
                case "USA":
                    language = "English";
                    break;
                case "Spain":
                case "Mexico":
                case "Argentina":
                    language = "Spanish";
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
            Console.WriteLine(language);
        }
    }
}
