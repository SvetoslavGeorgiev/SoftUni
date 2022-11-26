namespace SchoolMealsOrderingSystem.Core.Services
{
    using Contracts;
    using Data.Entities;
    using Microsoft.AspNetCore.Identity;
    using Models.SchoolUser;
    using System.Threading.Tasks;
    using static Data.Constants.RoleConstants;

    public class SchoolUserServices : ISchoolUserServices
    {
        public async Task<IdentityResult> AddSchoolUserToDatabase(
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            SchoolRegisterViewModel model)
        {
            var user = new SchoolUser
            {
                UserName = model.Email,
                SchoolName = model.SchoolName,
                Email = model.Email,
                IsSchool = true,
                IsDeleted = false
            };


            var result = await userManager.CreateAsync(user, model.Password);

            var schoolRole = await roleManager.FindByNameAsync(School);

            

            await userManager.AddToRoleAsync(user, schoolRole.Name);

            

            return result;
        }
    }
}
