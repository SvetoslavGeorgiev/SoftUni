using System;
using System.IO;

namespace Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var writer = new StreamWriter("Output.txt"))
            {
                using (var reader = new StreamReader("04. Merge Files/FileOne.txt"))
                {
                    var counter = 0;
                    using (var reader2 = new StreamReader("04. Merge Files/FileTwo.txt"))
                    {
                        
                        while (true)
                        {
                            var line = reader.ReadLine();
                            var line2 = reader2.ReadLine();


                            if (line != null)
                            {
                                writer.WriteLine(line);
                            }
                            if (line2 != null)
                            {
                                writer.WriteLine(line2);
                            }
                            if (line == null && line2 == null)
                            {
                                return;
                            }
                            counter++;
                        }
                    }
                }
            }
        }
    }
}
