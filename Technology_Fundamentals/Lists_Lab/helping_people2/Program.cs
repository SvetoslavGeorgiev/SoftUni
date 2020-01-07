using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationBasics
{
    class Program
    {
        static void PrintEvenOrOddNumbers(List<int> numbers, string command)
        {

            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenNumbers.Add(numbers[i]);
                }

                else
                {
                    oddNumbers.Add(numbers[i]);
                }
            }

            if (command == "printeven")
            {
                Console.WriteLine(string.Join(" ", evenNumbers));
            }

            else
            {
                Console.WriteLine(string.Join(" ", oddNumbers));
            }
        }

        static void PrintSum(List<int> numbers)
        {

            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            Console.WriteLine(sum);
        }

        static void printFilterredList(List<int> numbers, string condition, int filterValue)
        {

            List<int> smaller = new List<int>();
            List<int> smallerOrEven = new List<int>();
            List<int> bigger = new List<int>();
            List<int> biggerOrEven = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];

                if (currentNumber > filterValue)
                {
                    bigger.Add(currentNumber);
                }

                if (currentNumber >= filterValue)
                {
                    biggerOrEven.Add(currentNumber);
                }

                if (currentNumber < filterValue)
                {
                    smaller.Add(currentNumber);
                }

                if (currentNumber <= filterValue)
                {
                    smallerOrEven.Add(currentNumber);
                }
            }

            List<int> result = new List<int>();

            switch (condition)
            {
                case "<":
                    result = smaller;
                    break;

                case "<=":

                    result = smallerOrEven;
                    break;

                case ">":

                    result = bigger;
                    break;

                case ">=":
                    result = biggerOrEven;
                    break;
            }

            Console.WriteLine(string.Join(" ", result));
        }

        static void Main()
        {

            List<int> initialList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> numbers = new List<int>();

            numbers.AddRange(initialList);
            int counter = 0;

            string command = "";

            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                List<string> commandAsList = command
                    .Split()
                    .ToList();

                switch (commandAsList[0])
                {
                    case "add":

                        numbers.Add(int.Parse(commandAsList[1]));
                        counter++;
                        break;

                    case "remove":

                        numbers.Remove(int.Parse(commandAsList[1]));
                        counter++;
                        break;

                    case "removeat":

                        numbers.RemoveAt(int.Parse(commandAsList[1]));
                        counter++;
                        break;

                    case "insert":

                        numbers.Insert(int.Parse(commandAsList[2]), int.Parse(commandAsList[1]));
                        counter++;
                        break;

                    case "contains":

                        if (numbers.Contains(int.Parse(commandAsList[1])))
                        {
                            Console.WriteLine("Yes");
                        }

                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;

                    case "printeven":
                    case "printodd":

                        PrintEvenOrOddNumbers(numbers, commandAsList[0]);
                        break;

                    case "getsum":

                        PrintSum(numbers);
                        break;

                    case "filter":

                        printFilterredList(numbers, commandAsList[1], int.Parse(commandAsList[2]));
                        break;
                }

                //if (command == "insert" || command == "add" || command == "remove" || command == "removeat")
                //{
                //    counter++;
                //}
            }

            if (counter != 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}