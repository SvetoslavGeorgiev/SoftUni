namespace SchoolMealsOrderingSystem.Core.Services
{
    using Contracts;
    using Core.Models.School;
    using Data.Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using SchoolMealsOrderingSystem.Core.Models.Child;
    using SchoolMealsOrderingSystem.Data;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using static Data.Constants.RoleConstants;

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

            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(editSchoolUserViewModel.Password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            if (schoolUser != null)
            {
                schoolUser.SchoolName = editSchoolUserViewModel.SchoolName;
                schoolUser.PasswordHash = savedPasswordHash;
                schoolUser.Email = editSchoolUserViewModel.Email;

            }

            await schoolMealsOrderingSystemDbContext.SaveChangesAsync();
        }

        public async Task<EditSchoolUserViewModel> GetSchoolUserProfileAsync(string id)
        {
            var schoolUser = await schoolMealsOrderingSystemDbContext
                .SchoolUsers
                .Where(su => su.Id.Equals(id))
                .Select(su => new EditSchoolUserViewModel
                {
                    Id = su.Id,
                    SchoolName = su.SchoolName,
                    Email = su.Email

                })
                .SingleOrDefaultAsync();

            return schoolUser;
        }
    }
}
