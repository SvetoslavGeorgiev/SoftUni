using System;
using System.Linq;

namespace P03_Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var startIndex = input.LastIndexOf("\\") + 1;

            var file = input.Substring(startIndex);

            var splittedFile = file.Split(".")
                .ToList();

            Console.WriteLine($"File name: {splittedFile[0]}" +
                Environment.NewLine + $"File extension: {splittedFile[1]}");
        }
    }
}
