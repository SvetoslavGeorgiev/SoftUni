namespace Library.Data.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {

        public List<ApplicationUserBook> ApplicationUsersBooks { get; set; } = new List<ApplicationUserBook>();

    }
}
