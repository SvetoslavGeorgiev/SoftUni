namespace SchoolMealsOrderingSystem.Core.Models.SchoolUser
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Constants.GeneralConstants;

    public class SchoolLoginViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
