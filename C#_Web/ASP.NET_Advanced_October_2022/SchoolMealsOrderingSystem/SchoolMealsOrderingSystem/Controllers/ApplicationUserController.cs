namespace SchoolMealsOrderingSystem.Controllers
{
    using Data.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using static Data.Constants.RoleConstants;

    [Authorize]
    public class ApplicationUserController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private RoleManager<IdentityRole> roleManager;

        public ApplicationUserController(
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            RoleManager<IdentityRole> _roleManager)
        {
            UserManager = _userManager;
            SignInManager = _signInManager;
            RoleManager = _roleManager;
        }

        public UserManager<ApplicationUser> UserManager 
        { 
            get => userManager;  
            private set
            {
                userManager = value;
            }
        }

        public SignInManager<ApplicationUser> SignInManager
        {
            get => signInManager;
            private set
            {
                signInManager = value;
            }
        }

        public RoleManager<IdentityRole> RoleManager
        {
            get => roleManager;
            private set
            {
                roleManager = value;
            }
        }

        public async Task<IActionResult> CreateRoles()
        {
            await RoleManager.CreateAsync(new IdentityRole(School));
            await RoleManager.CreateAsync(new IdentityRole(Parent));

            return RedirectToAction("Index", "Home");
        }
    }
}
