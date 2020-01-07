using System;

namespace Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            string results = MiddleChars(inputString);

            Console.WriteLine(results);
        }

        private static string MiddleChars(string inputString)
        {
            string result = string.Empty;


            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString.Length % 2 == 0)
                {
                    if (i == inputString.Length / 2)
                    {
                        result += inputString[i-1];
                        result += inputString[i];
                    }
                }
                else if(i == inputString.Length / 2)
                {
                    result += inputString[i];
                }
            }
            return result;
        }
    }
}
