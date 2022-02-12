using System;
using System.Linq;
using System.Collections.Generic;

namespace _04_List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                var command2 = command.Split();
                var operation = command2[0];
                Operations(operation, numbers, command2);
            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Operations(string operation, List<int> numbers, string[] command2)
        {
            var newList = new List<int>();
            switch (operation)
            {
                case "Add":
                    newList = AddToTheList(numbers, command2);
                    break;
                case "Insert":
                    newList = InsertToTheList(numbers, command2);
                    break;
                case "Remove":
                    newList = RemoveFromTheList(numbers, command2);
                    break;
                case "Shift":
                    newList = MovingsInTheList(numbers, command2);
                    break;
                default:
                    break;
            }
        }

        private static List<int> MovingsInTheList(List<int> numbers, string[] command2)
        {
            var direction = command2[1];
            var count = int.Parse(command2[2]);
            var newList = new List<int>();
            if (direction == "left")
            {
                for (int i = 1; i <= count; i++)
                {
                    newList = AddToTheList(numbers);
                    newList = RemoveFromTheList(newList, 0);
                }
            }
            else
            {
                for (int i = 1; i <= count; i++)
                {
                    newList = InsertToTheList(numbers, 0);
                    newList = RemoveFromTheList(newList, numbers.Count - 1);
                }
            }
            return numbers;
        }

        private static List<int> InsertToTheList(List<int> listOfInts, int index)
        {
            listOfInts.Insert(0, listOfInts[listOfInts.Count - 1]);
            return listOfInts;
        }

        private static List<int> RemoveFromTheList(List<int> listOfInts, int index)
        {
            listOfInts.RemoveAt(index);
            return listOfInts;
        }

        private static List<int> AddToTheList(List<int> listOfInts)
        {
            listOfInts.Add(listOfInts[0]);
            return listOfInts;
        }

        private static List<int> RemoveFromTheList(List<int> listOfInts, string[] command2)
        {
            var index = int.Parse(command2[1]);
            if (index < 0 || index >= listOfInts.Count)
            {
                Console.WriteLine("Invalid index");
            }
            else
            {
                listOfInts.RemoveAt(index);
            }
            return listOfInts;
        }

        private static List<int> InsertToTheList(List<int> listOfInts, string[] command2)
        {
            var number = int.Parse(command2[1]);
            var index = int.Parse(command2[2]);
            if (index < 0 || index >= listOfInts.Count)
            {
                Console.WriteLine("Invalid index");
            }
            else
            {

                listOfInts.Insert(index, number);
            }
            return listOfInts;
        }

        private static List<int> AddToTheList(List<int> listOfInts, string[] command2)
        {
            var number = int.Parse(command2[1]);
            listOfInts.Add(number);
            return listOfInts;
        }
    }
}
