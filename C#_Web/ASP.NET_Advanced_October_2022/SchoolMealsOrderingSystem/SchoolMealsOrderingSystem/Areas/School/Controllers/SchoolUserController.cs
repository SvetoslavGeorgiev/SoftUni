﻿namespace SchoolMealsOrderingSystem.Areas.School.Controllers
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
    using Microsoft.Extensions.Localization;

    [Area(SchoolAreaName)]
    [Authorize(Roles = School)]
    [Route("/School/[controller]/[Action]/{id?}")]
    public class SchoolUserController : ApplicationUserController
    {

        private readonly ISchoolUserServices schoolUserServices;
        private readonly IStringLocalizer stringLocalizer;

        public SchoolUserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ISchoolUserServices _schoolUserServices,
            IStringLocalizer<SchoolUserController> _stringLocalizer)
            : base(userManager, signInManager, roleManager)
        {

            schoolUserServices = _schoolUserServices;
            stringLocalizer = _stringLocalizer;

        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home", new { area = SchoolAreaName });
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

                return RedirectToAction("Login", "SchoolUser", new { area = SchoolAreaName });
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
                return RedirectToAction("Index", "Home", new { area = SchoolAreaName });
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

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, stringLocalizer[ErrorMessage]);
                ModelState.AddModelError(string.Empty, stringLocalizer[SchoolInvalidEmail]);
                ModelState.AddModelError(string.Empty, stringLocalizer[WrongLoginPageForSchoolIfParent]);
                ModelState.AddModelError(string.Empty, stringLocalizer[WrongLoginPageForSchoolNeedEmail]);
                return View();
            }
            else if (model.Email != user.UserName)
            {
                ModelState.AddModelError(string.Empty, stringLocalizer[WrongLoginPageForSchoolIfParent]);
                ModelState.AddModelError(string.Empty, stringLocalizer[WrongLoginPageForSchoolNeedEmail]);
                return View();
            }

            if (user != null)
            {
                var result = await SignInManager.PasswordSignInAsync(user, model.Password, false, false);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = SchoolAreaName });
                }
            }

            return View(model);

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> DemoUserLogin()
        {

            var user = await UserManager.FindByEmailAsync("otec_paisiy@abv.bg");


            if (user != null && await UserManager.IsInRoleAsync(user, SchoolAreaName))
            {
                var result = await SignInManager.PasswordSignInAsync(user, "TpVnzNTcqR4XtES@", false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = SchoolAreaName });
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditSchoolProfile(string id)
        {

            var schoolUser = await schoolUserServices.GetSchoolUserProfileAsync(id);

            if (schoolUser == null)
            {
                return RedirectToAction("Index", "Home", new { area = SchoolAreaName });
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


                return RedirectToAction("Index", "Home", new { area = SchoolAreaName });

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

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await schoolUserServices.DeleteSchoolUserAsync(id);
            }
            catch (Exception)
            {

                throw new ArgumentException(ErrorMessage);
            }


            return RedirectToAction(nameof(Logout));
        }

    }
}
