using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            var counter = 0;

            var chars = new char[] { '-', ',', '.', '!', '?' };


            using (var reader = new StreamReader("text.txt"))
            {

                var currentLine = string.Empty;

                using (var writer = new StreamWriter("output.txt"))
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
