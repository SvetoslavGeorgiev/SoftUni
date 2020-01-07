using System;

namespace Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenghtOfTheString = int.Parse(Console.ReadLine());

            for (int i = 0; i < lenghtOfTheString; i++)
            {
                char firstChar = (char)('a' + i);
                for (int n = 0; n < lenghtOfTheString; n++)
                {
                    char secondChar = (char)('a' + n);
                    for (int k = 0; k < lenghtOfTheString; k++)
                    {
                        char thirdChar = (char)('a' + k);
                        Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");
                    }
                }
            }
            // this is another method for use!!!
            //for (char i = 'a'; i < 'a' + lenghtOfTheString; i++)
            //{
            //    for (char n = 'a'; n < 'a' + lenghtOfTheString; n++)
            //    {
            //        for (char k = 'a'; k < 'a' + lenghtOfTheString; k++)
            //        {
            //            Console.WriteLine($"{i}{n}{k}");
            //        }
            //    }
            //}
        }
    }
}
