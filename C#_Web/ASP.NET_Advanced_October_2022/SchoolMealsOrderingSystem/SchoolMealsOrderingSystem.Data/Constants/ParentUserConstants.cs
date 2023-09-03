namespace SchoolMealsOrderingSystem.Data.Constants
{
    public class ParentUserConstants
    {
        public const int FirstNameMaxLength = 30;
        public const int FirstNameMinLength = 5;

        public const int LastNameMaxLength = 597;
        public const int LastNameMinLength = 5;

        public const int UserNameMaxLength = 80;
        public const int UserNameMinLength = 5;

        public const int EmailMaxLength = 60;
        public const int EmailMinLength = 10;

        public const int PasswordMaxLength = 20;
        public const int PasswordMinLength = 5;


        public const string InvalidParentUserId = "invalid Parent Id";
        public const string InvalidUserName = "invalid UserName";

        public const string ParentAreaName = "Parent";

        public const string WrongLoginPageForParentIfScholl = "ifSchool";
        public const string WrongLoginPageForParentNeedUsername = "ifParent";
        public const string emailRegexPatern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        public const string UserNameErrorMessage = "Email addresses are not allowed as UserNames";

        
    }
}
