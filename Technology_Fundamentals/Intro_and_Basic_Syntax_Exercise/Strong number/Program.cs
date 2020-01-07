using System;

namespace Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = Console.ReadLine();

            var sum = 1;
            var totalSum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                int letter = number[i];

                char character = (char)letter;
                int val = (int)Char.GetNumericValue(character);


                for (int j = 1; j <= val; j++)
                {
                    sum *= j;
                }
                totalSum += sum;
                sum = 1;
            }
            int parseNumber = int.Parse(number);

            if (parseNumber == totalSum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
