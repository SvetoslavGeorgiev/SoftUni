using System;
using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"../../../TestFolder";

            string outputFilePath = @"../../../output.txt";


            GetFolderSize(folderPath, outputFilePath);

        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            var dir = new DirectoryInfo(folderPath);

            double sum = 0;

            foreach (var file in dir.GetFiles())
            {
                sum += file.Length;
            }
            foreach (var dir1 in dir.GetDirectories()) 
            {
                foreach (var item in dir1.GetFiles())
                {
                    sum += item.Length;
                }

            }   
            var sumInKb = sum / 1024;

            


            File.WriteAllText(outputFilePath, $"{sumInKb} KB");




        }

    }
}
