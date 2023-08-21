namespace SchoolMealsOrderingSystem.Core.Models.School
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Constants.GeneralConstants;

    public class SchoolLoginViewModel
    {
        [Required(ErrorMessage = EmailRequired)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = PasswordRequired)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
