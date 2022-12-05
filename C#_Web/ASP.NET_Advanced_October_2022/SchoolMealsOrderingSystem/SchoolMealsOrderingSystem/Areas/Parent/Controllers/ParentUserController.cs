namespace SchoolMealsOrderingSystem.Areas.Parent.Controllers
{
    using Data.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Core.Contracts;
    using Core.Models.Parent;
    using SchoolMealsOrderingSystem.Controllers;
    using static Data.Constants.GeneralConstants;
    using static Data.Constants.ParentUserConstants;
    using static Data.Constants.RoleConstants;

    [Area(ParentAreaName)]
    [Authorize(Roles = Parent)]
    [Route("Parent/[controller]/[Action]/{id?}")]
    public class ParentUserController : ApplicationUserController
    {
        private readonly IParentUserServices parentUserServices;

        public ParentUserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IParentUserServices _parentUserServices)
            : base(userManager, signInManager, roleManager)
        {
            parentUserServices = _parentUserServices;

        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new ParentRegisterViewModel();


            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new ParentLoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(ParentRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await parentUserServices.AddParentUserToDatabase(UserManager, RoleManager, model);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "ParentUser");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }

            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(ParentLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }



            var user = await UserManager.FindByNameAsync(model.UserName);

            if (model.UserName == user.Email)
            {
                ModelState.AddModelError(string.Empty, WrongLoginPageForParentIfScholl);
                ModelState.AddModelError(string.Empty, WrongLoginPageForParentNeedUsername);

                //return RedirectToAction("Login", "SchoolUser");
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

    }
}
