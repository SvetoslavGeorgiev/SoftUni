﻿namespace SchoolMealsOrderingSystem.Controllers
{
    using Core.Models.SchoolUser;
    using Data.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SchoolMealsOrderingSystem.Core.Contracts;
    using static Data.Constants.GeneralConstants;
    using static Data.Constants.SchoolUserConstants;
    using static Data.Constants.RoleConstants;

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

            schoolUserServices= _schoolUserServices;

        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
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
                return RedirectToAction("Index", "Home");
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
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, ErrorMessage);

            return View(model);

        }

    }
}
