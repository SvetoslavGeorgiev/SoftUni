using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {

            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            var counter = 0;

            var chars = new char[] { '-', ',', '.', '!', '?' };

            using (var reader = new StreamReader(inputFilePath))
            {
                var currentLine = string.Empty;

                using (var writer = new StreamWriter(outputFilePath))
                {

                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        counter++;
                        var allChars = 0;
                        var symbolCount = 0;

                        foreach (var @char in currentLine)
                        {
                            if (char.IsLetterOrDigit(@char))
                            {
                                allChars++;
                            }
                            else if (char.IsPunctuation(@char))
                            {
                                symbolCount++;
                            }
                        }

                        writer.WriteLine($"Line {counter}: {currentLine} ({allChars})({symbolCount})");
                    }
                }
            }
        }
    }
}
