namespace SchoolMealsOrderingSystem.Core.Contracts
{
    using Microsoft.AspNetCore.Identity;
    using SchoolMealsOrderingSystem.Core.Models.Child;
    using SchoolMealsOrderingSystem.Core.Models.SchoolUser;
    using SchoolMealsOrderingSystem.Data.Entities;

    public interface ISchoolUserServices
    {

        Task<IdentityResult> AddSchoolUserToDatabase(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SchoolRegisterViewModel model);

    }
}
