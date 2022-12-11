namespace SchoolMealsOrderingSystem.Core.Models.Parent
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Constants.ParentUserConstants;
    using static Data.Constants.GeneralConstants;

    public class EditParentUserViewModel
    {
        [UIHint(Hidden)]
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = UsernameRequired)]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength, ErrorMessage = FieldSymbolsLength)]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = NameRequired)]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = FieldSymbolsLength)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = LastNameRequired)]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = FieldSymbolsLength)]
        public string LastName { get; set; } = null!;

        
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
