namespace SchoolMealsOrderingSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SchoolMealsOrderingSystem.Core.Contracts;
    using System.Security.Claims;
    using static Data.Constants.DataConstants.SchoolUser;

    public class SchoolController : Controller
    {
        private readonly ISchoolServices schoolServices;

        public SchoolController(ISchoolServices _schoolServices)
        {
            schoolServices= _schoolServices;
        }


        public async Task<IActionResult> AllChildrenInSchool()
        {
            string schoolUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (schoolUserId == null)
            {
                throw new ArgumentException(InvalidSchoolUserId);
            }

            var model = await schoolServices.GetAllChildrenInSelectedSchoolAsync(schoolUserId);

            return View(model);
        }
    }
}
