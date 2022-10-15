namespace WebShopDemo.Data.Models.Account
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class ApplicationUser : IdentityUser
    {

        [StringLength(20)]
        public string? FirstName { get; set; }

        [StringLength(20)]
        public string? LastName { get; set; }


    }
}
