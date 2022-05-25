using System;
using System.Collections.Generic;
using System.Linq;

namespace P09_SoftUni_Exam_Results
{
    class P09_SoftUni_Exam_Results
    {
        static void Main()
        {
            var studentAndPoints = new Dictionary<string, int>();
            var courseAndSubmissions = new Dictionary<string, int>();

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "exam finished")
            {

                var currentSubmission = command.Split("-", StringSplitOptions.RemoveEmptyEntries);

                var student = currentSubmission[0];
                if (!currentSubmission.Contains("banned"))
                {


                    var course = currentSubmission[1];
                    var points = int.Parse(currentSubmission[2]);


                    if (studentAndPoints.ContainsKey(student))
                    {
                        if (points > studentAndPoints[student])
                        {
                            studentAndPoints[student] = points;
                        }
                    }
                    else
                    {
                        studentAndPoints.Add(student, points);
                    }

                    if (!courseAndSubmissions.ContainsKey(course))
                    {
                        courseAndSubmissions.Add(course, 0);
                    }
                    courseAndSubmissions[course]++;
                }
                else
                {
                    studentAndPoints.Remove(student);
                }
                
            }
            Console.WriteLine("Results: ");

            foreach (var student in studentAndPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var submission in courseAndSubmissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
