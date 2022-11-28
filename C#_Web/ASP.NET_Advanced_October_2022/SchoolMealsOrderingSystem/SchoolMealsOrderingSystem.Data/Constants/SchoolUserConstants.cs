namespace SchoolMealsOrderingSystem.Data.Constants
{
    public class SchoolUserConstants
    {
        public const int SchoolNameMaxLength = 80;
        public const int SchoolNameMinLength = 5;

        public const int EmailMaxLength = 60;
        public const int EmailMinLength = 10;

        public const int PasswordMaxLength = 20;
        public const int PasswordMinLength = 5;

        public const string InvalidSchoolUserId = "Invalid School Id";


        public const string WrongLoginPageForSchoolIfParent = "Ако сте регистриран родител моля влезте от \"Вход за родители\"!";
        public const string WrongLoginPageForSchoolNeedEmail = "Ако сте регистриранo училище моля въведете Email!";

    }
}
