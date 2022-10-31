namespace SchoolMealsOrderingSystem.Core.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SchoolMealsOrderingSystem.Data.Entities;

    public class ApplicationUserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public ApplicationUserController(SignInManager<ApplicationUser> _signInManager)
        {
            signInManager = _signInManager;
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
