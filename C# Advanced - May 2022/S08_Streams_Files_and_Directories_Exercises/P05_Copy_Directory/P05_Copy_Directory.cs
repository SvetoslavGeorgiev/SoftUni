namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = Console.ReadLine();
            string outputPath = Console.ReadLine();

            CopyAllFiles(inputPath, outputPath);
        }

        
        public static void CopyAllFiles(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo file in source.GetFiles())
            {
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);
            }

            // Copy each subdirectory using recursion.
            //foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            //{
            //    DirectoryInfo nextTargetSubDir =
            //        target.CreateSubdirectory(diSourceSubDir.Name);
            //    CopyAll(diSourceSubDir, nextTargetSubDir);
            //}
        }

        //public static void Main()
        //{
        //    string sourceDirectory = @"c:\sourceDirectory";
        //    string targetDirectory = @"c:\targetDirectory";

        //    Copy(sourceDirectory, targetDirectory);
        //}
    }
}