namespace SchoolMealsOrderingSystem.Areas.Parent.Controllers
{
    using Core.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using static Data.Constants.ParentUserConstants;
    using static Data.Constants.RoleConstants;

    [Area(ParentAreaName)]
    [Authorize(Roles = Parent)]
    [Route("/Parent/[controller]/[Action]/{id?}")]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}