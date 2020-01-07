using System;
using System.Linq;

namespace Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            str = str.ToLower();          // if this row not exist rows 32 - 36 need to exist!!!

            int vowelsCount = VowelsCounter(str);
            Console.WriteLine(vowelsCount);
        }

        private static int VowelsCounter(string str)
        {
            int counter = 0;

            char[] arr = str.ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                switch (arr[i])
                {
                    case 'a':
                    case 'o':
                    case 'u':
                    case 'e':
                    case 'i':
                    //case 'A':
                    //case 'O':
                    //case 'U':
                    //case 'E':
                    //case 'I':
                        counter++;
                        break;
                }
            }
            return counter;
        }
    }
}
