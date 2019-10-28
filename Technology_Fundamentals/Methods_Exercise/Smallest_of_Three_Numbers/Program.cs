using System;

namespace Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int result = SmallestNumber(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine(result);
        }

        private static int SmallestNumber(int firstNumber, int secondNumber, int thirdNumber)
        {
            int result = 0;
            if (firstNumber.CompareTo(secondNumber) < 0)
            {
                if (firstNumber.CompareTo(thirdNumber) < 0)
                {
                    result = firstNumber;
                }
                else
                {
                    result = thirdNumber;
                }
            }
            else if (firstNumber.CompareTo(secondNumber) > 0)
            {
                if (secondNumber.CompareTo(thirdNumber) < 0)
                {
                    result = secondNumber;
                }
                else
                {
                    result = thirdNumber;
                }
            }
            else
            {
                result = firstNumber;
            }
            return result;
        }
    }
}
