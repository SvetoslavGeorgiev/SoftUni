using System;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string operation = Console.ReadLine();

            double result = 0;
            double leftOver = 0;

            if (n2 == 0)
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
            }
            else if (operation == "/")
            {
                result = n1 / n2;
                Console.WriteLine($"{n1} / {n2} = {result:F2}");
            }
            else if (operation == "%")
            {
                leftOver = n1 % n2;
                Console.WriteLine($"{n1} % {n2} = {leftOver}");
            }
            else if (operation == "+")
            {
                result = n1 + n2;
                leftOver = result % 2;

                if (leftOver == 0)
                {
                    Console.WriteLine($"{n1} {operation} {n2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} {operation} {n2} = {result} - odd");
                }
            }
            else if (operation == "-")
            {
                result = n1 - n2;
                leftOver = result % 2;

                if (leftOver == 0)
                {
                    Console.WriteLine($"{n1} {operation} {n2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} {operation} {n2} = {result} - odd");
                }
            }
            else if (operation == "*")
            {
                result = n1 * n2;
                leftOver = result % 2;

                if (leftOver == 0)
                {
                    Console.WriteLine($"{n1} {operation} {n2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} {operation} {n2} = {result} - odd");
                }
            }
            
        }
    }
}
