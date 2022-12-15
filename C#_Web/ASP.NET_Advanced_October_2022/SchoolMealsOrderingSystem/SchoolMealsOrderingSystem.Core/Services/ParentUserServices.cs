namespace SchoolMealsOrderingSystem.Core.Services
{
    using Contracts;
    using Data.Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Models.Parent;
    using SchoolMealsOrderingSystem.Data;
    using System.Threading.Tasks;
    using static Data.Constants.ParentUserConstants;
    using static Data.Constants.RoleConstants;

    public class ParentUserServices : IParentUserServices
    {

        private readonly SchoolMealsOrderingSystemDbContext schoolMealsOrderingSystemDbContext;
        private readonly IChildServices childServices;

        public ParentUserServices(SchoolMealsOrderingSystemDbContext _schoolMealsOrderingSystemDbContext, IChildServices _childServices)
        {
            schoolMealsOrderingSystemDbContext = _schoolMealsOrderingSystemDbContext;
            childServices = _childServices;
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
                .Where(pu => pu.Id.Equals(id) && !pu.IsDeleted)
                .Select(pu => new EditParentUserViewModel
                {
                    Id = pu.Id,
                    UserName = pu.UserName,
                    FirstName = pu.FirstName,
                    LastName = pu.LastName,
                    Email = pu.Email

                })
                .SingleOrDefaultAsync();

            if (parentUser == null)
            {
                throw new ArgumentException(InvalidParentUserId);
            }

            return parentUser;
        }

        public async Task EditParentUserAsync(EditParentUserViewModel editParentUserViewModel)
        {
            var parentUser = await schoolMealsOrderingSystemDbContext
                .ParentUsers.FindAsync(editParentUserViewModel.Id);

            if (parentUser == null)
            {
                throw new ArgumentException(InvalidParentUserId);
            }

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

        public async Task DeleteParentUserAsync(string ParentUserId)
        {
            var user = await schoolMealsOrderingSystemDbContext
                .ParentUsers
                .Where(pu => pu.Id == ParentUserId && !pu.IsDeleted)
                .Include(pu => pu.ParentsChildren.Where(pc => !pc.Child.IsDeleted))
                .FirstOrDefaultAsync();

            var str = Guid.NewGuid().ToString();

            if (user != null)
            {
                user.IsDeleted = true;
                user.UserName = str;
                user.FirstName = string.Empty;
                user.LastName = string.Empty;
                user.PasswordHash = string.Empty;
                user.Email = string.Empty;
                user.PhoneNumber = string.Empty;
                user.NormalizedEmail = string.Empty;
                user.NormalizedUserName = str.ToUpper();
                user.ConcurrencyStamp = string.Empty;
                user.SecurityStamp = string.Empty;

                if (user.ParentsChildren.Any())
                {
                    foreach (var item in user.ParentsChildren)
                    {

                        await childServices.DeleteChildAsync(item.ChildId);

                    }
                }

                await schoolMealsOrderingSystemDbContext.SaveChangesAsync();
            }
        }

    }
}
