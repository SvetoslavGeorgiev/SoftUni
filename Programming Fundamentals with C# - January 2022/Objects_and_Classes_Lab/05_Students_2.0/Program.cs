using System;
using System.Collections.Generic;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                var data = command.Split();

                var firstName = data[0];
                var lastName = data[1];
                var ages = int.Parse(data[2]);
                var town = data[3];



                if (IsSudentExisting(students, firstName, lastName))
                {
                    Student student = GetStudent(students, firstName, lastName);

                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Ages = ages;
                    student.Town = town;

                }
                else
                {
                    Student student = new Student();
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Ages = ages;
                    student.Town = town;

                    students.Add(student);
                }
            }
            string inputTown = Console.ReadLine();

            foreach (var student in students)
            {
                if (student.Town == inputTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Ages} years old.");
                }
            }
        }

        private static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;

            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }

            return existingStudent;
        }

        private static bool IsSudentExisting(List<Student> students, string firstName, string lastName)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }
            return false;
        }

        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Ages { get; set; }
            public string Town { get; set; }
        }
    }
}

