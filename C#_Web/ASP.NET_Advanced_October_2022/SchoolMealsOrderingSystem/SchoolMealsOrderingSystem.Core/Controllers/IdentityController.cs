namespace SchoolMealsOrderingSystem.Core.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class IdentityController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

    }
}
