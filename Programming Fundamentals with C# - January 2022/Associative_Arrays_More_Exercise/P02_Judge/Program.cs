using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var command = string.Empty;

            var dataBase = new Dictionary<string,List<Student>>();
            var individualStanding = new Dictionary<string, int>();

            while ((command = Console.ReadLine()) != "no more time")
            {
                var tokens = command.Split(" -> ");
                var contestName = tokens[1];
                var studentName = tokens[0];
                var studentPoints = int.Parse(tokens[2]);
                var currentStudent = new Student(studentName, studentPoints);
                if (!dataBase.ContainsKey(contestName))
                {
                    dataBase.Add(contestName, new List<Student>());
                    dataBase[contestName].Add(currentStudent);
                }
                else
                {
                    var isExist = false;
                    foreach (var student in dataBase[contestName])
                    {
                        if (student.Name == studentName)
                        {
                            isExist = true;
                            if (studentPoints > student.Points)
                            {
                                student.Points = studentPoints;
                            }
                        }
                    }
                    if (!isExist)
                    {
                        dataBase[contestName].Add(currentStudent);
                    }
                }
            }

            foreach (var kvp in dataBase)
            {
                foreach (var student in kvp.Value)
                {
                    var studentName = student.Name;
                    var studentPoints = student.Points;
                    if (!individualStanding.ContainsKey(studentName))
                    {
                        individualStanding.Add(studentName, studentPoints);
                    }
                    else
                    {
                        individualStanding[studentName] += studentPoints;
                    }
                }
            }

            foreach (var kvp in dataBase)
            {
                var contest = kvp.Key;

                var participants = dataBase[contest].Count;

                Console.WriteLine($"{contest}: {participants} participants");
                var number = 0;
                foreach (var student in kvp.Value.OrderByDescending(x => x.Points).ThenBy(x => x.Name))
                {
                    number++;

                    Console.WriteLine($"{number}. {student.Name} <::> {student.Points}");

                }
            }
            Console.WriteLine("Individual standings:");
            var counter = 0;
            foreach (var kvp in individualStanding.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                counter++;
                Console.WriteLine($"{counter}. {kvp.Key} -> {kvp.Value}");
            }
        }

        public class Student
        {
            public Student()
            {

            }

            public Student(string name, int points)
            {
                Name = name;
                Points = points;
            }

            public string Name { get; set; }
            public int Points { get; set; }

        }
    }
}
