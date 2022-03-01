using System;
using System.Collections.Generic;
using System.Linq;


namespace Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());

            ListOfArticles listOfArticles = new ListOfArticles();

            listOfArticles = AddingNewArticleToThisList(listOfArticles, numberOfArticles);

            string criteria = Console.ReadLine();

            OrderedAndWriteArticleByGivenCriteria(listOfArticles, criteria);
        }


        private static void OrderedAndWriteArticleByGivenCriteria(ListOfArticles listOfArticles, string criteria)
        {
            if (criteria == "title")
            {
                foreach (var title in listOfArticles.Articles.OrderBy(x => x.Title))
                {
                    Console.WriteLine(title.ToString());
                }
            }
            else if (criteria == "content")
            {
                foreach (var content in listOfArticles.Articles.OrderBy(x => x.Content))
                {
                    Console.WriteLine(content.ToString());
                }
            }
            else
            {
                foreach (var author in listOfArticles.Articles.OrderBy(x => x.Author))
                {
                    Console.WriteLine(author.ToString());

                }
            }

        }
        private static ListOfArticles AddingNewArticleToThisList(ListOfArticles listOfArticles, int numberOfArticles)
        {
            for (int i = 1; i <= numberOfArticles; i++)
            {
                List<string> article = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
                Article newArticle = new Article(article[0], article[1], article[2]);

                listOfArticles.Articles.Add(newArticle);

            }
            return listOfArticles;
        }
        class Article
        {

            public Article(string title, string content, string author)
            {
                Title = title;
                Content = content;
                Author = author;
            }
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }



            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
        class ListOfArticles
        {
            public ListOfArticles()
            {
                Articles = new List<Article>();
            }
            public List<Article> Articles { get; set; }
        }
    }
}
