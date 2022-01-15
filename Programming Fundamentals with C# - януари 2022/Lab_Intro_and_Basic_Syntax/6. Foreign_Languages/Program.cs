using System;

namespace _6._Foreign_Languages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var country = Console.ReadLine();

            var spokenLanguage = string.Empty;

            switch (country)
            {
                case "USA":
                case "England":
                    spokenLanguage = "English";
                    break;
                case "Mexico":
                case "Spain":
                case "Argentina":
                    spokenLanguage = "Spanish";
                    break;
                default:
                    spokenLanguage = "unknown";
                    break;
            }
            Console.WriteLine(spokenLanguage);
        }
    }
}
