using System;

namespace _09_Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var type = Console.ReadLine();
            var firstValue = Console.ReadLine();
            var secondValue = Console.ReadLine();

            string result = GetTheGreaterValue(type, firstValue, secondValue);
            Console.WriteLine(result);
        }

        private static string GetTheGreaterValue(string type, string firstValue, string secondValue)
        {
            var result = string.Empty;
            switch (type)
            {
                case "int":
                    var intResult = Math.Max(int.Parse(firstValue), int.Parse(secondValue));
                    result = intResult.ToString();
                    break;
                case "char":
                    int currentOne = Math.Max(char.Parse(firstValue), char.Parse(secondValue));
                    char val = (char)currentOne;
                    result = val.ToString();

                    break;
                case "string":
                    string currentResult = string.Compare(firstValue, secondValue).ToString();

                    if (int.Parse(currentResult) < 0)
                    {
                        result = secondValue;
                    }
                    else if (int.Parse(currentResult) > 0)
                    {
                        result = firstValue;
                    }
                    break;
                default:
                    break;
            }

            return result;

        }
    }
}
