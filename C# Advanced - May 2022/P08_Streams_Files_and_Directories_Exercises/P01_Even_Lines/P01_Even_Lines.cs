namespace EvenLines
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            ProcessLines(inputFilePath); 

        }

        public static string ProcessLines(string inputFilePath)
        {
            //var lines = new List<string>();
            char[] charArr = new char[] { '-', ',', '.', '!', '?' };

            using (var reader = new StreamReader(inputFilePath))
            {

                var counter = 0;

                var line = string.Empty;

                while ((line = reader.ReadLine()) != null)
                {

                    var list = new List<string>();

                    if (counter % 2 == 0)
                    {
                        list = line.Split(' ').ToList();

                        for (   int i = 0; i < list.Count; i++)
                        {
                            foreach (var ch in charArr)
                            {
                                if (list[i].Contains(ch))
                                {

                                    var word = ChangeCharInString(list[i], charArr);

                                    list[i] = word;

                                }
                            }
                        }

                        list.Reverse();

                        //lines.Add(string.Join(" ", list));
                        Console.WriteLine(string.Join(" ", list));
                    }
                    counter++;
                }
            }
            return string.Empty;
            //return string.Join("\r\n", lines);
        }

        public static string ChangeCharInString(string word, char[] charArr)
        {


            foreach (var item in word)
            {
                if (charArr.Contains(item))
                {
                    word = word.Replace(item, '@');
                }
            }

            return word;
        }
    }
}
