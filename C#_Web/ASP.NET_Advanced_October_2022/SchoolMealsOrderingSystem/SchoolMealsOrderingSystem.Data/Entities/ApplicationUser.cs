namespace SchoolMealsOrderingSystem.Data.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public bool IsDeleted { get; set; } = false;

        public bool IsSchool { get; set; } = false;
    }
}
