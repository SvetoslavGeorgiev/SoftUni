namespace SchoolMealsOrderingSystem.Areas.School.Controllers
{
    using Core.Models.School;
    using Core.Contracts;
    using Data.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SchoolMealsOrderingSystem.Controllers;
    using static Data.Constants.GeneralConstants;
    using static Data.Constants.RoleConstants;
    using static Data.Constants.SchoolUserConstants;
    using SchoolMealsOrderingSystem.Core.Services;

    [Area(School)]
    [Authorize(Roles = School)]
    public class SchoolUserController : ApplicationUserController
    {

        private readonly ISchoolUserServices schoolUserServices;

        public SchoolUserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ISchoolUserServices _schoolUserServices)
            : base(userManager, signInManager, roleManager)
        {

            schoolUserServices = _schoolUserServices;

        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var model = new SchoolRegisterViewModel();


            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(SchoolRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await schoolUserServices.AddSchoolUserToDatabase(UserManager, RoleManager, model);


            if (result.Succeeded)
            {

                return RedirectToAction("Login", "SchoolUser");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var model = new SchoolLoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(SchoolLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await UserManager.FindByEmailAsync(model.Email);

            if (model.Email != user.UserName)
            {
                ModelState.AddModelError(string.Empty, WrongLoginPageForSchoolIfParent);
                ModelState.AddModelError(string.Empty, WrongLoginPageForSchoolNeedEmail);
                //return RedirectToAction("Login", "ParentUser");
                return View();
            }

            if (user != null)
            {
                var result = await SignInManager.PasswordSignInAsync(user, model.Password, false, false);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }

            ModelState.AddModelError(string.Empty, ErrorMessage);

            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> EditSchoolProfile(string id)
        {

            var schoolUser = await schoolUserServices.GetSchoolUserProfileAsync(id);

            if (schoolUser == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View(schoolUser);

        }

        [HttpPost]
        public async Task<IActionResult> EditSchoolProfile(EditSchoolUserViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {

                await schoolUserServices.EditSchoolUserAsync(model);


                return RedirectToAction("Index", "Home", new { area = "" });

            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, InvalidSchoolUserId);

                return View(model);
            }

        }

        
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}
