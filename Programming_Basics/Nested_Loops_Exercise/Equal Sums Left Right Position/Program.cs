using System;

namespace Equal_Sums_Left_Right_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            

            for (int i = number1; i <= number2; i++)
            {
                string currentNum = i.ToString();

                int leftsum = 0;
                int rightSum = 0;
                int middleDigit = 0;

                for (int j = 0; j < currentNum.Length; j++)

                {
                    
                    int currentDigit = int.Parse(currentNum[j].ToString());

                    if (j == 0 || j == 1)
                    {
                        leftsum += currentDigit;
                    }
                    else if (j == 3 || j == 4)
                    {
                        rightSum += currentDigit;
                    }
                    else
                    {
                        middleDigit = currentDigit;
                    }
                }
                if (leftsum == rightSum)
                {
                    Console.Write($"{currentNum} ");
                }
                else if (leftsum > rightSum)
                {
                    rightSum += middleDigit;
                    if (leftsum == rightSum)
                    {
                        Console.Write($"{currentNum} ");
                    }
                    
                }
                else if (rightSum > leftsum)
                {
                    leftsum += middleDigit;
                    if (leftsum == rightSum)
                    {
                        Console.Write($"{currentNum} ");
                    }
                    
                }
                   
            }
        }
    }
}
