namespace SchoolMealsOrderingSystem.Core.Services
{
    using Contracts;
    using Core.Models.School;
    using Data.Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using SchoolMealsOrderingSystem.Data;
    using System.Threading.Tasks;
    using static Data.Constants.RoleConstants;
    using static Data.Constants.SchoolUserConstants;

    public class SchoolUserServices : ISchoolUserServices
    {
        private readonly SchoolMealsOrderingSystemDbContext schoolMealsOrderingSystemDbContext;

        public SchoolUserServices(SchoolMealsOrderingSystemDbContext _schoolMealsOrderingSystemDbContext)
        {
            schoolMealsOrderingSystemDbContext = _schoolMealsOrderingSystemDbContext;
        }

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

        public async Task EditSchoolUserAsync(EditSchoolUserViewModel editSchoolUserViewModel)
        {
            var schoolUser = await schoolMealsOrderingSystemDbContext
                .SchoolUsers.FindAsync(editSchoolUserViewModel.Id);

            if (schoolUser == null)
            {
                throw new ArgumentException(InvalidSchoolUserId);
            }

            var hasher = new PasswordHasher<ApplicationUser>();

            var savedPasswordHash = hasher.HashPassword(schoolUser, editSchoolUserViewModel.Password);


            if (schoolUser != null)
            {
                schoolUser.SchoolName = editSchoolUserViewModel.SchoolName;
                schoolUser.PasswordHash = savedPasswordHash;

            }

            await schoolMealsOrderingSystemDbContext.SaveChangesAsync();
        }

        public async Task<EditSchoolUserViewModel> GetSchoolUserProfileAsync(string id)
        {
            var schoolUser = await schoolMealsOrderingSystemDbContext
                .SchoolUsers
                .Where(su => su.Id.Equals(id) && !su.IsDeleted)
                .Select(su => new EditSchoolUserViewModel
                {
                    Id = su.Id,
                    SchoolName = su.SchoolName,
                    Email = su.Email

                })
                .SingleOrDefaultAsync();

            if (schoolUser == null)
            {
                throw new ArgumentException(InvalidSchoolUserId);
            }

            return schoolUser;
        }

        public async Task DeleteSchoolUserAsync(string SchoolUserId)
        {
            var user = await schoolMealsOrderingSystemDbContext
                .SchoolUsers
                .Where(pu => pu.Id == SchoolUserId && !pu.IsDeleted)
                .FirstOrDefaultAsync();

            var str = Guid.NewGuid().ToString();

            if (user != null)
            {
                user.IsDeleted = true;
                user.UserName = str;
                user.SchoolName = string.Empty;
                user.PasswordHash = string.Empty;
                user.Email = string.Empty;
                user.PhoneNumber = string.Empty;
                user.NormalizedEmail = string.Empty;
                user.NormalizedUserName = str.ToUpper();
                user.ConcurrencyStamp = string.Empty;
                user.SecurityStamp = string.Empty;

                

                await schoolMealsOrderingSystemDbContext.SaveChangesAsync();
            }
        }
    }
}
