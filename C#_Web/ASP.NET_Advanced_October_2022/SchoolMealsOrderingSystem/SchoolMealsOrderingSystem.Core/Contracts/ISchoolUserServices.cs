namespace SchoolMealsOrderingSystem.Core.Contracts
{
    using Microsoft.AspNetCore.Identity;
    using Core.Models.School;
    using Data.Entities;

    public interface ISchoolUserServices
    {

        Task<IdentityResult> AddSchoolUserToDatabase(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SchoolRegisterViewModel model);

        Task<EditSchoolUserViewModel> GetSchoolUserProfileAsync(string id);

        Task EditSchoolUserAsync(EditSchoolUserViewModel editSchoolUserViewModel);

    }
}
