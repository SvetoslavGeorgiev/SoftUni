namespace SchoolMealsOrderingSystem.Core.Services
{
    using Contracts;
    using Data.Entities;
    using Microsoft.AspNetCore.Identity;
    using Models.Parent;
    using System.Threading.Tasks;
    using static Data.Constants.RoleConstants;

    public class ParentUserServices : IParentUserServices
    {
        public async Task<IdentityResult> AddParentUserToDatabase(
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            ParentRegisterViewModel model)
        {
            var user = new ParentUser
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsSchool = false,
                Email = model.Email,
                IsDeleted = false
            };

            var result = await userManager.CreateAsync(user, model.Password);

            var parentRole = await roleManager.FindByNameAsync(Parent);

            await userManager.AddToRoleAsync(user, parentRole.Name);

            return result;
        }
    }
}
