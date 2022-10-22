namespace ForumApp.Data
{
    public class DataConstants
    {

        public class ApplicationUser
        {
            public const int UsernameMaxLength = 20;
            public const int UsernameMinLength = 5;

            public const int EmailMaxLength = 60;
            public const int EmailMinLength = 10;

            public const int PasswordMaxLength = 20;
            public const int PasswordMinLength = 5;

            public const string InvalidUserId = "Invalid User Id";
        }

        public class Book
        {
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 10;

            public const int AuthorMaxLength = 50;
            public const int AuthorMinLength = 5;

            public const int DescriptionMaxLength = 5000;
            public const int DescriptionMinLength = 5;

            public const string RatingMin = "0.00";
            public const string RatingMax = "10.00";
            public const string RatingDecimal = "decimal(18,2)";

            public const string InvalidBook = "You have entered invalid or incorrect data!";
            public const string InexistentCategory = "Category does not exist";
            public const string InvalidBookId = "Invalid Book Id";


        }

        public class Category
        {
            public const int CategoryNameMaxLength = 50;
            public const int CategoryNameMinLength = 5;
        }

        public class ControllerConstants
        {
            public static string ErrorMessage = "Something went wrong. Please try again!";
        }

    }
}
