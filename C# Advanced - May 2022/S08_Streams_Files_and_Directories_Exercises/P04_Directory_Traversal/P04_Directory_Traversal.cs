namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            var dir = Directory.GetFiles(inputFolderPath);

            var dictionary = new Dictionary<string, Dictionary<string, double>>();

            List<string> list = new List<string>();

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

            foreach (var kvp in dictionary.OrderByDescending(x => x.Value.Count))
            {
                list.Add(kvp.Key);
                foreach (var file in kvp.Value.OrderBy(x => x.Key))
                {
                    list.Add($"--{file.Key} - {file.Value}kb");
                }
            }

            return string.Join("\r\n", list);
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {

            using (var writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName, true))
            {

                writer.WriteLine(textContent);

            }
        }
    }
}
