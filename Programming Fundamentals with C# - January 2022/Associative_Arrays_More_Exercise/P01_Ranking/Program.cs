using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var dataBase = new Dictionary<string, Dictionary<string, List<Student>>>();

            var command = string.Empty;

            var bestCandidate = string.Empty;
            var bestPoints = 0;

            while ((command = Console.ReadLine()) != "end of contests")
            {
                var tokens = command.Split(':');

                var contest = tokens[0];
                var passwordForTheContest = tokens[1];

                dataBase.Add(contest, new Dictionary<string, List<Student>>());
                dataBase[contest].Add(passwordForTheContest, new List<Student>());
            }

            while ((command = Console.ReadLine()) != "end of submissions")
            {

                var tokens = command.Split("=>");

                var contest = tokens[0];
                var passwordForTheContest = tokens[1];
                var username = tokens[2];
                var points = int.Parse(tokens[3]);




                if (dataBase.ContainsKey(contest))
                {
                    foreach (var kvp in dataBase[contest])
                    {

                        if (kvp.Key == passwordForTheContest)
                        {
                            var IsExist = false;
                            foreach (var student in kvp.Value)
                            {
                                if (student.Name == username)
                                {
                                    IsExist = true;
                                    if (student.Points < points)
                                    {
                                        student.Points = points;
                                    }
                                }
                            }
                            if (!IsExist)
                            {
                                var currentStudent = new Student(username, points);

                                kvp.Value.Add(currentStudent);
                            }
                            
                        }
                    }
                }
            }

            var dataForPrint = new Dictionary<string, Dictionary<string, int>>();

            foreach (var kvp in dataBase)
            {

                var contest = kvp.Key;

                foreach (var item in kvp.Value)
                {
                    foreach(var student in item.Value)
                    {

                        if (dataForPrint.ContainsKey(student.Name))
                        {
                            dataForPrint[student.Name].Add(contest, student.Points);
                        }
                        else
                        {
                            dataForPrint.Add(student.Name, new Dictionary<string, int>());
                            dataForPrint[student.Name].Add(contest, student.Points);
                        }
                    }

                }

            }




            foreach (var item in dataForPrint)
            {
                var currentPoints = item.Value.Sum(x => x.Value);
                if (bestPoints < currentPoints)
                {
                    bestPoints = currentPoints;
                    bestCandidate = item.Key;

                }
            }



            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var kvp in dataForPrint.OrderBy(x => x.Key))
            {

                Console.WriteLine(kvp.Key);

                foreach (var item in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
            }
        }
    }

    //public class Students
    //{
    //    List<Student> students = new List<Student>();
    //}

    public class Student 
    {
        public Student()
        {

        }

        //public Student(string contest, string passwordForTheContest)
        //{
        //    Contest = contest;
        //    PasswordForTheContest = passwordForTheContest;
        //}

        //public Student(string contest, string passwordForTheContest, string name, int points)
        //{
        //    Contest = contest;
        //    PasswordForTheContest = passwordForTheContest;
        //    Name = name;
        //    Points = points;
        //}

        public Student(string name, int points)
        {
            Name = name;
            Points = points;
        }

        public string Contest { get; set; }
        public string PasswordForTheContest { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }

    }

}
