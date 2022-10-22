namespace Library.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.ApplicationUser;

    public class RegisterViewModel
    {

        [Required]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

    }
}
