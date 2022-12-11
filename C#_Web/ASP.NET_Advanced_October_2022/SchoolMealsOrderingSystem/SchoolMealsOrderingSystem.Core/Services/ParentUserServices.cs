namespace SchoolMealsOrderingSystem.Core.Services
{
    using Contracts;
    using Data.Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Models.Parent;
    using SchoolMealsOrderingSystem.Core.Models.School;
    using SchoolMealsOrderingSystem.Data;
    using System.Threading.Tasks;
    using static Data.Constants.RoleConstants;

    public class ParentUserServices : IParentUserServices
    {

        private readonly SchoolMealsOrderingSystemDbContext schoolMealsOrderingSystemDbContext;

        public ParentUserServices(SchoolMealsOrderingSystemDbContext _schoolMealsOrderingSystemDbContext)
        {
            schoolMealsOrderingSystemDbContext = _schoolMealsOrderingSystemDbContext;
        }


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

        public async Task<EditParentUserViewModel> GetParentUserProfileAsync(string id)
        {
            var parentUser = await schoolMealsOrderingSystemDbContext
                .ParentUsers
                .Where(pu => pu.Id.Equals(id))
                .Select(pu => new EditParentUserViewModel
                {
                    Id = pu.Id,
                    UserName = pu.UserName,
                    FirstName= pu.FirstName,
                    LastName= pu.LastName,
                    Email = pu.Email

                })
                .SingleOrDefaultAsync();

            return parentUser;
        }

        public async Task EditParentUserAsync(EditParentUserViewModel editParentUserViewModel)
        {
            var parentUser = await schoolMealsOrderingSystemDbContext
                .ParentUsers.FindAsync(editParentUserViewModel.Id);

            var hasher = new PasswordHasher<ApplicationUser>();

            var savedPasswordHash = hasher.HashPassword(parentUser, editParentUserViewModel.Password);


            if (parentUser != null)
            {
                parentUser.UserName = editParentUserViewModel.UserName;
                parentUser.FirstName = editParentUserViewModel.FirstName;
                parentUser.LastName = editParentUserViewModel.LastName;
                parentUser.PasswordHash = savedPasswordHash;

            }

            await schoolMealsOrderingSystemDbContext.SaveChangesAsync();
        }

    }
}
