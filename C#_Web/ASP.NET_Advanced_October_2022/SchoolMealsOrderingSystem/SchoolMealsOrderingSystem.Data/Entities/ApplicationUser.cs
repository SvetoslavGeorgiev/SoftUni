namespace SchoolMealsOrderingSystem.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using SchoolMealsOrderingSystem.Data.Interfaces;

    public class ApplicationUser : IdentityUser, IsDeletable
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
