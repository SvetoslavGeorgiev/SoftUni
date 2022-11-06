﻿namespace SchoolMealsOrderingSystem.Data.Constants
{
    
    public class DataConstants
    {

        public class ParentUser
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

            public const int RelationToChildMaxLength = 20;
            public const int RelationToChildMixLength = 4;

            public const int ParentChildRelationMaxLength = 30;
            public const int ParentChildRelationMixLength = 30;

            public const string InvalidParentUserId = "Invalid Parent Id";
        }

        public class SchoolUser
        {
            public const int SchoolNameMaxLength = 80;
            public const int SchoolNameMinLength = 5;

            public const int EmailMaxLength = 60;
            public const int EmailMinLength = 10;

            public const int PasswordMaxLength = 20;
            public const int PasswordMinLength = 5;

            public const string InvalidSchoolUserId = "Invalid School Id";
        }


        public class Child
        {

            public const int FirstNameMaxLength = 30;
            public const int FirstNameMinLength = 5;

            public const int LastNameMaxLength = 597;
            public const int LastNameMinLength = 5;

            public const string InvalidChildUserId = "Invalid Child Id";

        }

        public class GeneralConstants
        {
            public static string ErrorMessage = "Something went wrong. Please try again!";
        }


    }
}
