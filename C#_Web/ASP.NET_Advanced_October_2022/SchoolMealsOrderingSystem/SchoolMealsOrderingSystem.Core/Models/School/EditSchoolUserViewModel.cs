namespace SchoolMealsOrderingSystem.Core.Models.School
{
    using System.ComponentModel.DataAnnotations;

    using static Data.Constants.SchoolUserConstants;
    using static Data.Constants.GeneralConstants;

    public class EditSchoolUserViewModel
    {
        [UIHint(Hidden)]
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = SchoolNameRequired)]
        [StringLength(SchoolNameMaxLength, MinimumLength = SchoolNameMinLength, ErrorMessage = FieldSymbolsLength)]
        public string SchoolName { get; set; } = null!;

        [EmailAddress(ErrorMessage = InvalidEmail)]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = FieldSymbolsLength)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = PasswordRequired)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = FieldSymbolsLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password), ErrorMessage = PasswordAndConfirmPasswordEquality)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = PasswordConfirmRequired)]
        public string ConfirmPassword { get; set; } = null!;


    }
}
