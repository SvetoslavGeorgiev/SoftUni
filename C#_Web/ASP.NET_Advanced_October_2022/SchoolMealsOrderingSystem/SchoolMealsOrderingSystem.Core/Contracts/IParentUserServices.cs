namespace SchoolMealsOrderingSystem.Core.Contracts
{
    using Microsoft.AspNetCore.Identity;
    using Models.Parent;
    using Data.Entities;

    public interface IParentUserServices
    {

        Task<IdentityResult> AddParentUserToDatabase(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ParentRegisterViewModel model);

        Task<EditParentUserViewModel> GetParentUserProfileAsync(string id);

        Task EditParentUserAsync(EditParentUserViewModel editParentUserViewModel);

        Task DeleteParentUserAsync(string ParentUserId);
    }
}
