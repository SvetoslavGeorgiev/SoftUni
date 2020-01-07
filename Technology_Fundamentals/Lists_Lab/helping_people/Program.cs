using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationBasics
{
    class Program
    {
        static void PrintEvenOrOddNumbers(List<int> numbers, string command)
        {

            List<int> evenNumbers = numbers.Where(x => x % 2 == 0).ToList();
            List<int> oddNumbers = numbers.Where(x => x % 2 != 0).ToList();

            if (command == "PrintEven")
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

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandAsArray = command
                    .Split();

                switch (commandAsArray[0])
                {
                    case "Add":

                        numbers.Add(int.Parse(commandAsArray[1]));
                        counter++;
                        break;

                    case "Remove":

                        numbers.Remove(int.Parse(commandAsArray[1]));
                        counter++;
                        break;

                    case "RemoveAt":

                        numbers.RemoveAt(int.Parse(commandAsArray[1]));
                        counter++;
                        break;

                    case "Insert":

                        numbers.Insert(int.Parse(commandAsArray[2]), int.Parse(commandAsArray[1]));
                        counter++;
                        break;

                    case "Contains":

                        if (numbers.Contains(int.Parse(commandAsArray[1])))
                        {
                            Console.WriteLine("Yes");
                        }

                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;

                    case "PrintEven":
                    case "PrintOdd":

                        PrintEvenOrOddNumbers(numbers, commandAsArray[0]);
                        break;

                    case "GetSum":

                        PrintSum(numbers);
                        break;

                    case "Filter":

                        printFilterredList(numbers, commandAsArray[1], int.Parse(commandAsArray[2]));
                        break;
                }

                //if (command == "Insert" || command == "Add" || command == "Remove" || command == "RemoveAt")
                //{
                //  counter++;
                //}
                command = Console.ReadLine();
            }

            if (counter != 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}