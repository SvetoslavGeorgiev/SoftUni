using System;
using System.Collections.Generic;
using System.Linq;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            ListOfStudents listOfStudents = new ListOfStudents();

            listOfStudents = GetAddNewStudent(listOfStudents, numberOfStudents);

            foreach (var student in listOfStudents.FirstListOfStudents.OrderByDescending(x => x.Grade))
            {
                Console.WriteLine(student);
            }
        }

        private static ListOfStudents GetAddNewStudent(ListOfStudents listOfStudents, int numberOfStudents)
        {
            for (int i = 1; i <= numberOfStudents; i++)
            {
                List<string> student = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var parceGrade = float.Parse(student[2]);
                Student newStudent = new Student(student[0], student[1], parceGrade);
                listOfStudents.FirstListOfStudents.Add(newStudent);
            }
            return listOfStudents;
        }

        class Student
        {
            public Student(string firstName, string lastName, float grade)
            {
                FirstName = firstName;
                LastName = lastName;
                Grade = grade;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public float Grade { get; set; }

            public override string ToString()
            {
                return $"{FirstName} {LastName}: {Grade:F2}";
            }
        }

        class ListOfStudents
        {
            public ListOfStudents()
            {
                FirstListOfStudents = new List<Student>();
            }
            public List<Student> FirstListOfStudents { get; set; }
        }
    }
}