namespace SchoolMealsOrderingSystem.Core.Models.SchoolUser
{
    using System.ComponentModel.DataAnnotations;

    public class SchoolLoginViewModel
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
