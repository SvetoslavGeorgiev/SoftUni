namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.Data.SqlClient.Server;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Windows.Markup;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();

            //DbInitializer.ResetDatabase(db);



            var result = CountCopiesByAuthor(db);

            Console.WriteLine(result);


        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {

            //AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            AgeRestriction ageRestriction;

            bool isParsed = Enum.TryParse(command, true, out ageRestriction);

            if (!isParsed)
            {
                return string.Empty;
            }

            var books = string.Join($"{Environment.NewLine}", context
                .Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList());

            return books;



        }

        public static string GetGoldenBooks(BookShopContext context)
        {

            var books = string.Join(Environment.NewLine, context
                .Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList());

            return books;

        }

        public static string GetBooksByPrice(BookShopContext context)
        {

            var books = string.Join(separator: Environment.NewLine, context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:F2}")
                .ToList());

            return books;

        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {

            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);

        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {

            
            var categories = input.ToLower().Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);


            var Books = string.Join(Environment.NewLine, context
            .Books
            .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
            .Select(b => b.Title)
            .OrderBy(t => t));
             
            return Books;

        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();

            var dateConverted = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context
                .Books
                .Where(b => b.ReleaseDate < dateConverted)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price
                })
                .ToList();


            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var authors = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {

            var Books = string.Join(Environment.NewLine, context
            .Books
            .Where(b => b.Title.ToLower().Contains(input.ToLower()))
            .Select(b => b.Title)
            .OrderBy(b => b)
            .ToList());

            return Books;

        }


        public static string GetBooksByAuthor(BookShopContext context, string input)
        {


            var books = string.Join(separator: Environment.NewLine, context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToList());

            return books;

        }


        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var count = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList()
                .Count();

            return count;
        }


        public static string CountCopiesByAuthor(BookShopContext context)
        {

            var sb = new StringBuilder();

            var copiesByAuthor = context
                .Authors
                .Select(a => new
                {
                    AuthorName = $"{a.FirstName} {a.LastName}",
                    TotalCopies = a.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(x => x.TotalCopies)
                .ToList();


            copiesByAuthor.ForEach(ca => sb.AppendLine($"{ca.AuthorName} - {ca.TotalCopies}"));

            return sb.ToString().TrimEnd();
        }

    }
}
