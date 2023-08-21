namespace SchoolMealsOrderingSystem.Core.Models.Parent
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Constants.GeneralConstants;

    public class ParentLoginViewModel
    {
        [Required(ErrorMessage = UsernameRequired)]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = PasswordRequired)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
