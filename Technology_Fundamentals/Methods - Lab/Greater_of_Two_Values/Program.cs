using System;

namespace Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            

            if (type == "int")
            {
                int firstNumber = int.Parse(Console.ReadLine());
                int secondNumber = int.Parse(Console.ReadLine());
                int resullt = GetMax(firstNumber, secondNumber);
                Console.WriteLine(resullt);
            }
            else if (type == "char")
            {
                
                char firstChar = char.Parse(Console.ReadLine());
                char secondChar = char.Parse(Console.ReadLine());
                char results = GetMax(firstChar, secondChar);
                Console.WriteLine(results);
            }
            else if (type == "string")
            {
                string firstString = Console.ReadLine();
                string secondString = Console.ReadLine();
                string result = GetMax(firstString, secondString);
                Console.WriteLine(result);
            }

        }

        private static string GetMax(string firstString, string secondString)
        {
            //int sumOfFirstString = 0;
            //int sumOfSecondString = 0;
            //char[] first = firstString.ToCharArray();
            //char[] second = secondString.ToCharArray();
            //for (int i = 0; i < firstString.Length; i++)
            //{
            //    sumOfFirstString += first[i];
            //}
            //for (int i = 0; i < secondString.Length; i++)
            //{
            //    sumOfSecondString += second[i];
            //}
            //if (sumOfFirstString > sumOfSecondString)
            //{
            //    return firstString;
            //}
            //if (sumOfSecondString > sumOfFirstString)
            //{
            //    return secondString;
            //}
            //else
            //{
            //    return firstString;
            //}
            if (String.Compare(firstString, secondString) < 0)
            {
                return secondString;
            }
            else if (String.Compare(firstString, secondString) > 0)
            {
                return firstString;
            }
            else
            {
                return firstString;
            }


        }
        private static int GetMax(int firstNumber, int secondNumber)
        {
            if (firstNumber > secondNumber)
            {
                return firstNumber;
            }
            else if (secondNumber > firstNumber)
            {
                return secondNumber;
            }
            else
            {
                return firstNumber;
            }
        }
        private static char GetMax(char firstChar, char secondChar)
        {
            if (firstChar > secondChar)
            {
                return firstChar;
            }
            else if (secondChar > firstChar)
            {
                return secondChar;
            }
            else
            {
                return firstChar;
            }
        }
    }
}
