namespace SchoolMealsOrderingSystem.Core.Models.ParentUser
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Constants.DataConstants.ParentUser;
    public class ParentRegisterViewModel
    {

        [Required(ErrorMessage = "Полето \"Потребителско Име\" е задължително")]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength, ErrorMessage = "Полето трябва да е между {2} и {1} символа")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Полето \"{0}\" е задължително")]
        [EmailAddress]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = "Полето трябва да е между {2} и {1} символа")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Полето \"Парола\" е задължително")]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "Полето трябва да е между {2} и {1} символа")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Полето \"Потвърждаване на Парола\" е задължително")]
        public string ConfirmPassword { get; set; } = null!;

    }
}
