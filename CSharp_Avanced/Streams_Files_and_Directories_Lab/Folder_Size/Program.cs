using System;
using System.IO;

namespace Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            var dir = new DirectoryInfo("06. Folder Size/TestFolder");

            double sum = 0;

            foreach (var file in dir.GetFiles())
            {
                sum += file.Length;
            }

            var sumInMb = sum / 1024 / 1024;

            File.WriteAllText("оutput.txt", sumInMb.ToString());

        }
    }
}
