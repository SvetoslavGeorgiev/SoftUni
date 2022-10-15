namespace WebShopDemo.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {


        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [Compare(nameof(ConfirmPassword))]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;


        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; } = null!;


    }
}
