namespace WebShopDemo.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using WebShopDemo.Core.Constants;
    using WebShopDemo.Data.Models.Account;
    using WebShopDemo.Models;

    public class AccountController : BaseController
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();

            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                EmailConfirmed = true,
                LastName = model.LastName,
                UserName = model.Email
            };


            var result = await userManager.CreateAsync(user, model.Password);
            await userManager
                .AddClaimAsync(user, new System.Security.Claims.Claim(ClaimTypeConstants.FirstName, user.FirstName ?? user.Email));

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");

            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }


            return View(model);


        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            var model = new LoginViewModel()
            {
                ReturnUrl = returnUrl,
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {

                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);


                if (result.Succeeded)
                {

                    if (model.ReturnUrl != null)
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login");

            return View(model);


        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> CreateRoles()
        {
            await roleManager.CreateAsync(new IdentityRole(RoleConstants.Manager));
            await roleManager.CreateAsync(new IdentityRole(RoleConstants.Supervisor));
            await roleManager.CreateAsync(new IdentityRole(RoleConstants.Administrator));

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> AddUsersToRoles()
        {
            var email1 = "mihailgeorgiev15@gmail.com";
            var email2 = "svetoslavgeorgiev86@gmail.com";

            var user = await userManager.FindByEmailAsync(email1);
            var user2 = await userManager.FindByEmailAsync(email2);

            await userManager.AddToRoleAsync(user, RoleConstants.Manager);
            await userManager.AddToRolesAsync(user2, new string[] { RoleConstants.Supervisor, RoleConstants.Manager });


            return RedirectToAction("Index", "Home");
        }
    }
}
