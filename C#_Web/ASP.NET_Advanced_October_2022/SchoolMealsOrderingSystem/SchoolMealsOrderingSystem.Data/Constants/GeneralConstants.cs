﻿namespace SchoolMealsOrderingSystem.Data.Constants
{
    using System.Collections.Generic;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

    public class GeneralConstants
    {

        public const string UsernameRequired = "UserName_Required";
        public const string NameRequired = "FirstName_Required";
        public const string LastNameRequired = "LastName_Required";
        public const string PasswordRequired = "Password_Required";
        public const string PasswordConfirmRequired = "ConfirmPassword_Required";
        public const string EmailRequired = "Email_Required";
        public const string ParentChildRelationRequired = "RelationToChild_Required";
        public const string ImageUrlRequired = "ImageUrl_Required";
        public const string BirthDayRequired = "Birthday_Required";
        public const string YearInSchoolRequired = "YearInSchool_Required";
        public const string SchoolNameRequired = "SchoolUserId_Required";
        public const string IngredientsRequired = "Ingredients_Required";
        public const string AllergensRequired = "Allergens_Required";
        public const string UrlRequired = "ImageUrl_Required";

        public const string PasswordAndConfirmPasswordEquality = "ConfirmPassword_Compare";

        public const string FieldSymbolsLength = "FirstName_StringLength";
        public const string EmailAddress = "Моля въведете Email адрес на училището";
        public const string InvalidMenu = "Менюто още не е налично";
        public const string InvalidEmail = "Email_EmailAddress";
        public const string InvalidUser = "Невалиден потребител";
        public const string ErrorMessage = "errorMessage";

        public const string AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ чявертъуиопшщасдфгхйклюзьцжбнмЧЯВЕРТЪУИОПШЩАСДФГХЙКЛЮЗЬЦЖБНМ";
        public const string Hidden = "hidden";
        public const string HomePage = "homePage";

        //Layaut constants

        public const string LayoutTitleName = "title";
        public const string LayoutTitleString = "Title";
        public const string LayoutIndexString = "index";
        public const string LayoutChildrenString = "children";
        public const string LayoutAddChildString = "addChild";
        public const string LayoutChildrenInSchoolString = "childrenInSchool";
        public const string LayoutHomeString = "home";
        public const string LayoutChooseLangString = "chooseLang";
        public const string LayoutBulgarianLangString = "bg";
        public const string LayoutEnglishLangString = "en";
        public const string LayoutChooseWeeklyMenuString = "chooseWeeklyMenu";
        public const string LayoutMealString = "Meal";
        public const string LayoutAllMealsString = "allMeals";
        public const string LayoutAddDishString = "addDish";
        public const string LayoutAddSoupString = "addSoup";
        public const string LayoutAddMainDishString = "addMainDish";
        public const string LayoutAddDessertString = "addDessert";
        public const string LayoutAddSoupActionString = "AddSoup";
        public const string LayoutAddMainDishActionString = "AddMainDish";
        public const string LayoutAddDessertActionString = "AddDessert";
        public const string LayoutAllMainDishesActionString = "AllMainDishes";
        public const string LayoutAllSoupsActionString = "AllSoups";
        public const string LayoutAllDessertsActionString = "AllDesserts";
        public const string LayoutSoupsString = "soups";
        public const string LayoutMainDishesString = "mainDishes";
        public const string LayoutDessertsString = "desserts";

        //LoginPartial constansts

        public const string LoginPartialProfile = "profile";
        public const string LoginPartialLogout = "logout";
        public const string LoginPartialSignUp = "signUp";
        public const string LoginPartialLogin = "login";
        public const string LoginPartialForParents = "loginForParents";
        public const string LoginPartialForSchools = "loginForSchools";
        public const string LoginPartialSignUpForSchools = "SignUpForSchools";
        public const string LoginPartialSignUpForParents = "SignUpForParents";


        //constants for child/add

        public const string Name = "name";
        public const string LastName = "lastName";
        public const string RelationToCild = "relationToChild";
        public const string Birthday = "birthday";
        public const string ChooseSchool = "chooseSchool";
        public const string YearInSchool = "yearInSchool";
        public const string Add = "add";
        public const string Confirm = "confirm";
        public const string Image = "image";


        //constants for Area/Parent/Views/ParenUser/Register

        public const string UserName = "userName";
        public const string Email = "email";
        public const string Password = "password";
        public const string PasswordConfirmation = "passwordConfirmation";
        public const string Register = "register";

        //constants for Area/Parent/Views/ParenUser/Login

        public const string ParentLogin = "parentLogin";
        public const string Login = "login";
        public const string UseDemoUser = "useDemoUser";

        //constants for Area/Parent/Views/ParenUser/EditParentProfile

        public const string Changes = "changes";
        public const string Delete = "delete";

        //constants for Area/Parent/Views/SchoolUser/Register

        public const string SchoolInvalidEmail = "invalidEmail";
        public const string SchoolName = "schoolName";

        //constants for all Home/Index pages

        public const string TranslationMessage = "message";

        //constants for all DailyMenu/GetMealsForParentsToChoose

        public const string Day = "day";
        public const string YouHaveChosenAMenuForEveryDay = "youHaveChosenAMenuForEveryDay";
        public const string ChooseTheDayOfTheMenu = "chooseTheDayOfTheMenu";
        public const string ChooseSoup = "chooseSoup";
        public const string ChooseAMainDish = "chooseAMainDish";
        public const string ChooseADessert = "chooseADessert";
        public const string SeeSoups = "seeSoups";
        public const string SeeMainDishes = "seeMainDishes";
        public const string SeeDesserts = "seeDesserts";
        public const string Monday = "monday";
        public const string Tuesday = "tuesday";
        public const string Wednesday = "wednesday";
        public const string Thursday = "thursday";
        public const string Friday = "friday";

        //constants for all DailyMenu/All

        public const string NoSelectedMenusYet = "noSelectedMenusYet";
        public const string SoupString = "soup";
        public const string MainDishString = "mainDish";
        public const string DessertString = "dessert";

        //constants for all Meal/AddMealsToSchoolList

        public const string SoupFirstChoice = "soupFirstChoice";
        public const string SoupSecondChoice = "soupSecondChoice";
        public const string SoupThirdChoice = "soupThirdChoice";
        public const string MainDishFirstChoice = "mainDishFirstChoice";
        public const string MainDishSecondChoice = "mainDishSecondChoice";
        public const string MainDishThirdChoice = "mainDishThirdChoice";
        public const string DessertFirstChoice = "dessertFirstChoice";
        public const string DessertSecondChoice = "dessertSecondChoice";
        public const string DessertThirdChoice = "dessertThirdChoice";

        //constants for all Meal/AddSoup

        public const string Description = "description";
        public const string Ingredients = "ingredients";
        public const string ImageUrl = "imageUrl";
        public const string Allergens = "allergens";


    }
}
