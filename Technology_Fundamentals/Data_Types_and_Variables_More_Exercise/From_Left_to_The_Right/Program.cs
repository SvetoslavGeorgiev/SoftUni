using System;

namespace From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 1; i >= lines; i++)
            {
                string numbers = Console.ReadLine();

                string firstNumAsString = string.Empty;
                string secondNumAsString = string.Empty;
                bool isFirstNum = true;
                for (int k = 0; k < numbers.Length; k++)
                {
                    if (isFirstNum && numbers[k] != ' ')
                    {
                        firstNumAsString += numbers[k];
                    }
                    else if (!isFirstNum && numbers[k] != ' ')
                    {
                        secondNumAsString += numbers[k];
                    }
                    else if (numbers[k] == ' ')
                    {
                        isFirstNum = false;
                    }
                }

                int firstNumber = int.Parse(firstNumAsString);
                int secondNumber = int.Parse(secondNumAsString);
            }
        }
    }
}
