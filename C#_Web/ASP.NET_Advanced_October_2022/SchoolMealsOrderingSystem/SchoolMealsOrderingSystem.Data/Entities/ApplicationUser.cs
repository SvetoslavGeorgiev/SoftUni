namespace SchoolMealsOrderingSystem.Data.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            IsDeleted= false;
            IsSchool= false;
        }

        public bool IsDeleted { get; set; }

        public bool IsSchool { get; set; }
    }
}
