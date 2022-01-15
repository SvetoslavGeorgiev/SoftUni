using System;

namespace Student_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentName = Console.ReadLine();
            var studentAge = int.Parse(Console.ReadLine());
            var studentAverageGrade = double.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {studentName}, Age: {studentAge}, Grade: {studentAverageGrade:F2}"); 
        }
    }
}
