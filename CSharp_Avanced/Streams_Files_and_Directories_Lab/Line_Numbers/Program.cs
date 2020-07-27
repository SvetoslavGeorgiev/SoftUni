using System;
using System.IO;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("Resources/02. Line Numbers/Input.txt"))
            {
                using (var writer = new StreamWriter("Output.txt"))
                {
                    var counter = 1;

                    while (true)
                    {
                        var line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        line = $"{counter}. {line}";

                        counter++;

                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
