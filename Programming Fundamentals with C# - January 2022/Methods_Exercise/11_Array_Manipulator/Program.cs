using System;
using System.Linq;

namespace _11_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                
                var input = command.Split();
                if (input[0] == "exchange")
                {
                    if (int.Parse(input[1]) < 0 || int.Parse(input[1]) >= numberArr.Length)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numberArr = Exchange(input, numberArr);
                    }
                }
                else if (input[0] == "min" || input[0] == "max")
                {
                    PrintMinMaxEvenOddIndex(numberArr, input);
                }
                else
                {
                    PrintGivenCountOfEvenOrOddsNumbersFromTheFrontOrEnd(input, numberArr);
                }
            }
            Console.WriteLine($"[{string.Join(", ", numberArr)}]");
        }

        private static void PrintGivenCountOfEvenOrOddsNumbersFromTheFrontOrEnd(string[] input, int[] numberArr)
        {
            var frontOrLast = input[0];
            var count = int.Parse(input[1]);
            var evenOrOdds = input[2];

            if (count > numberArr.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                var resultArr = new int[count];
                var currentCount = 0;
                
                if (evenOrOdds == "odd")
                {
                    if (frontOrLast == "first")
                    {
                        var startIndex = 0;
                        for (int i = 0; i < count; i++)
                        {
                            for (int k = startIndex; k < numberArr.Length; k++)
                            {
                                if (numberArr[k] % 2 != 0)
                                {
                                    resultArr[i] = numberArr[k];
                                    currentCount++;
                                    startIndex = k + 1;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        var startIndex = numberArr.Length - 1;
                        for (int i = 0; i < count; i++)
                        {
                            
                            for (int k = startIndex; k >= 0; k--)
                            {
                                if (numberArr[k] % 2 != 0)
                                {
                                    
                                    resultArr[i] = numberArr[k];
                                    currentCount++;
                                    startIndex = k - 1;
                                    break;
                                }
                            }
                        }
                        Array.Resize(ref resultArr, currentCount);
                        Array.Reverse(resultArr);
                        
                    }
                }
                else
                {
                    if (frontOrLast == "first")
                    {
                        var startIndex = 0;
                        for (int i = 0; i < count; i++)
                        {
                            for (int k = startIndex; k < numberArr.Length; k++)
                            {
                                if (numberArr[k] % 2 == 0)
                                {
                                    resultArr[i] = numberArr[k];
                                    currentCount++;
                                    startIndex = k + 1;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        var startIndex = numberArr.Length - 1;
                        for (int i = 0; i < count; i++)
                        {

                            for (int k = startIndex; k >= 0; k--)
                            {
                                if (numberArr[k] % 2 == 0)
                                {

                                    resultArr[i] = numberArr[k];
                                    currentCount++;
                                    startIndex = k - 1;
                                    break;
                                }
                            }
                        }
                        Array.Resize(ref resultArr, currentCount);
                        Array.Reverse(resultArr);
                    }
                }
                if (currentCount == 0)
                {
                    Console.WriteLine("[]");
                }
                else
                {
                    Array.Resize(ref resultArr, currentCount);
                    Console.WriteLine($"[{string.Join(", ", resultArr)}]");
                }

            }
        }

        private static void PrintMinMaxEvenOddIndex(int[] numberArr, string[] input)
        {
            var index = -1;
            if (input[0] == "min")
            {
                if (input[1] == "even")
                {
                    int minNum = int.MaxValue;
                    for (int i = 0; i < numberArr.Length; i++)
                    {
                        var currentNum = numberArr[i];
                        
                        
                        if (currentNum % 2 == 0 && currentNum <= minNum)
                        {
                            minNum = currentNum;
                            index = i;
                        }

                    }
                }
                else
                {
                    int minNum = int.MaxValue;
                    for (int i = 0; i < numberArr.Length; i++)
                    {
                        var currentNum = numberArr[i];
                        

                        if (currentNum % 2 != 0 && currentNum <= minNum)
                        {
                            minNum = currentNum;
                            index = i;
                        }

                    }
                }
            }
            else
            {
                if (input[1] == "even")
                {
                    int maxNum = int.MinValue;
                    for (int i = 0; i < numberArr.Length; i++)
                    {
                        var currentNum = numberArr[i];
                        

                        if (currentNum % 2 == 0 && currentNum >= maxNum)
                        {
                            maxNum = currentNum;
                            index = i;
                        }

                    }
                }
                else
                {
                    int maxNum = int.MinValue;
                    for (int i = 0; i < numberArr.Length; i++)
                    {
                        var currentNum = numberArr[i];
                        
                        if (currentNum % 2 != 0 && currentNum >= maxNum)
                        {
                            maxNum = currentNum;
                            index = i;
                        }

                    }
                }
            }
            if (index != -1)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static int[] Exchange(string[] input, int[] numberArr)
        {
            
            var resultArr = new int[numberArr.Length];
            var index = int.Parse(input[1]);
            

            for (int k = index + 1; k < numberArr.Length; k++)
            {
                var diff = index + 1;
                resultArr[k - diff] = numberArr[k];
            }
            for (int k = 0; k <= index; k++)
            {
                var diff = numberArr.Length - 1 - index; 
                resultArr[k + diff] = numberArr[k];
            }
            return resultArr;
        }
    }
}
