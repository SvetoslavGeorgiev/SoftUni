namespace SchoolMealsOrderingSystem.Areas.Parent.Controllers
{
    using Core.Contracts;
    using Core.Models.Parent;
    using Data.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
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
                return RedirectToAction("Index", "Home", new { area = ParentAreaName });
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
                return RedirectToAction("Index", "Home", new { area = ParentAreaName });
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
                return RedirectToAction("Login", "ParentUser", new { area = ParentAreaName });
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

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, InvalidUserName);
            }
            else if (model.UserName == user.Email)
            {
                ModelState.AddModelError(string.Empty, WrongLoginPageForParentIfScholl);
                ModelState.AddModelError(string.Empty, WrongLoginPageForParentNeedUsername);

                return View();
            }

            if (user != null && await UserManager.IsInRoleAsync(user, ParentAreaName))
            {
                var result = await SignInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = ParentAreaName });
                }
            }

            ModelState.AddModelError(string.Empty, ErrorMessage);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditParentProfile(string id)
        {

            var parentUser = await parentUserServices.GetParentUserProfileAsync(id);

            if (parentUser == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View(parentUser);

        }

        [HttpPost]
        public async Task<IActionResult> EditParentProfile(EditParentUserViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {

                await parentUserServices.EditParentUserAsync(model);


                return RedirectToAction("Index", "Home", new { area = ParentAreaName });

            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, InvalidParentUserId);

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
                await parentUserServices.DeleteParentUserAsync(id);
            }
            catch (Exception)
            {

                throw new ArgumentException(ErrorMessage);
            }
            

            return RedirectToAction(nameof(Logout));


        }

    }
}
