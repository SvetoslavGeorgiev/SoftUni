namespace SchoolMealsOrderingSystem.Core.Models.SchoolUser
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Constants.DataConstants.ParentUser;
    public class SchoolRegisterViewModel
    {

        [Required]
        [EmailAddress(ErrorMessage = "Полето {0} е задължително")]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Полето \"Парола\" е задължително")]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

    }
}
