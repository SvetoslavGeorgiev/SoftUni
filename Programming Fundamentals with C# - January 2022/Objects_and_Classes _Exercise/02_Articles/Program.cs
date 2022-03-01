using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Articles
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> article = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            int numberOfChanges = int.Parse(Console.ReadLine());
            Article newArticle = new Article();

            newArticle.Title = article[0];
            newArticle.Content = article[1];
            newArticle.Author = article[2];

            for (int i = 1; i <= numberOfChanges; i++)
            {
                var command = Console.ReadLine();

                var splitedCommand = command.Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (splitedCommand[0] == "Edit")
                {
                    newArticle.Edit(splitedCommand[1]);
                }
                else if (splitedCommand[0] == "ChangeAuthor")
                {
                    newArticle.ChangeAuthor(splitedCommand[1]);
                }
                else
                {
                    newArticle.Rename(splitedCommand[1]);
                }
            }

            Console.WriteLine(newArticle.ToString());
        }
    }

    class Article
    {

        public string Edit(string content)
        {
            Content = content;
            return Content;
        }
        public string ChangeAuthor(string author)
        {
            Author = author;
            return Author;
        }

        public string Rename(string title)
        {
            Title = title;
            return Title;
        }
        public Article()
        {

        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
