namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();

            //DbInitializer.ResetDatabase(db);

            var result = GetBooksByPrice(db);

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

            var books = string.Join($"{Environment.NewLine}", context
                .Books
                .Where(b =>b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList());

            return books;

        }

        public static string GetBooksByPrice(BookShopContext context)
        {

            var books = string.Join($"{Environment.NewLine}", context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:F2}")
                .ToList());

            return books;

        }
    }
}
