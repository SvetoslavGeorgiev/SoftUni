namespace SchoolMealsOrderingSystem.Core.Models.ParentUser
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Constants.DataConstants.ParentUser;
    public class ParentRegisterViewModel
    {

        [Required(ErrorMessage = "Полето \"Потребителско Име\" е задължително")]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength, ErrorMessage = "Полето трябва да е между {2} и {1} символа")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Полето \"Име\" е задължително")]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = "Полето трябва да е между {2} и {1} символа")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Полето \"Фамилия\" е задължително")]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = "Полето трябва да е между {2} и {1} символа")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Полето \"Връзката ви с детето\" е задължително")]
        [StringLength(RelationToChildMaxLength, MinimumLength = RelationToChildMixLength, ErrorMessage = "Полето трябва да е между {2} и {1} символа")]
        public string RelationToChild { get; set; } = null!;

        [Required(ErrorMessage = "Полето \"{0}\" е задължително")]
        [EmailAddress(ErrorMessage ="Невалиден Email")]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = "Полето трябва да е между {2} и {1} символа")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Полето \"Парола\" е задължително")]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "Полето трябва да е между {2} и {1} символа")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password), ErrorMessage = "\"Паролата\" и \"Потвърждаване на паролата\" не съвпадат")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Полето \"Потвърждаване на парола\" е задължително")]
        public string ConfirmPassword { get; set; } = null!;

    }
}
