using System;
using System.IO;

namespace Slice_File
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please eter the amount of part you want to split:");
            int fileCount = int.Parse(Console.ReadLine());

            using (var reader = new FileStream("05. Slice File/sliceMe.txt", FileMode.Open))
            {
                var lenght = (long)Math.Ceiling((double)reader.Length / fileCount);


                for (int i = 1; i <= fileCount; i++)
                {
                    
                    var currentFile = $"slice-{i}.txt";
                    long currentFileLenght = 0;
                    using (var writer = new FileStream($"05. Slice File/{currentFile}", FileMode.Create))
                    {
                        var buffer = new byte[4096];

                        var total = reader.Read(buffer, 0, buffer.Length);

                        while (total == buffer.Length)
                        {
                            currentFileLenght += buffer.Length;

                            writer.Write(buffer, 0, buffer.Length);
                            if (currentFileLenght >= lenght)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
