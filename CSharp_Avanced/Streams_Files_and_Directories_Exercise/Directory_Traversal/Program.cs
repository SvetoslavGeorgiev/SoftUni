using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var dir = Directory.GetFiles("D:/documents");

            var dictionary = new Dictionary<string, Dictionary<string, double>>();

            foreach (var file in dir)
            {
                var fileInfo = new FileInfo(file);
                var currentFileName = fileInfo.Name;
                var splitcCurrentFileName = currentFileName.Split(".").ToArray();
                double currentFileSizeInKb = (double)Math.Ceiling((decimal)fileInfo.Length / 1024);

                if (!dictionary.ContainsKey($".{splitcCurrentFileName[1]}"))
                {
                    dictionary.Add($".{splitcCurrentFileName[1]}", new Dictionary<string, double>());
                }
                dictionary[$".{splitcCurrentFileName[1]}"].Add(currentFileName, currentFileSizeInKb);
            }

            using (var writer = new StreamWriter("Output.txt"))
            {

                foreach (var kvp in dictionary.OrderByDescending(x => x.Value.Count))
                {
                    writer.WriteLine(kvp.Key);
                    foreach (var file in kvp.Value.OrderBy(x => x.Key))
                    {
                        writer.WriteLine($"--{file.Key} - {file.Value}kb");
                    }
                }
            }
        }
    }
}