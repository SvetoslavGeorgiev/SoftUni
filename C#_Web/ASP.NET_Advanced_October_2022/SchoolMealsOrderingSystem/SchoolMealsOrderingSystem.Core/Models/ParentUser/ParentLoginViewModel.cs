namespace SchoolMealsOrderingSystem.Core.Models.ParentUser
{
    using System.ComponentModel.DataAnnotations;

    public class ParentLoginViewModel
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
