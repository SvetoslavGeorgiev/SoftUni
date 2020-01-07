using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = string.Empty;

            var peopleList = new List<string>();

            var coursesDictionary = new Dictionary<string, List<string>>();

            while ((command = Console.ReadLine()) != "end")
            {
                var splittedCommand = command.Split(" : ");

                if (coursesDictionary.ContainsKey(splittedCommand[0]))
                {
                    coursesDictionary[splittedCommand[0]].Add(splittedCommand[1]);
                }
                else
                {
                    coursesDictionary.Add(splittedCommand[0], peopleList);
                    coursesDictionary[splittedCommand[0]].Add(splittedCommand[1]);
                }
                peopleList = new List<string>();
            }

            foreach (var course in coursesDictionary.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var people in course.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {people}");
                }
            }
        }
    }
}