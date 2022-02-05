using System;

namespace _03_Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var toDo = Console.ReadLine();
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());

            int result = Calculations(toDo, firstNumber, secondNumber);
            Console.WriteLine(result);
        }

        private static int Calculations(string toDo, int firstNumber, int secondNumber)
        {
            int result = 0;

            switch (toDo)
            {
                case "add":
                    result = firstNumber + secondNumber;
                    break;
                case "multiply":
                    result = firstNumber * secondNumber;
                    break;
                case "subtract":
                    result = firstNumber - secondNumber;
                    break;
                case "divide":
                    result = firstNumber / secondNumber;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
