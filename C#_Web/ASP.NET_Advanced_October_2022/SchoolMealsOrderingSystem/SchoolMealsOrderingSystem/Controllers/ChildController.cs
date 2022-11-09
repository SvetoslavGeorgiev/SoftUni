namespace SchoolMealsOrderingSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SchoolMealsOrderingSystem.Core.Contracts;
    using SchoolMealsOrderingSystem.Core.Models.Child;
    using System.Security.Claims;
    using static Data.Constants.DataConstants.Child;
    using static Data.Constants.DataConstants.ParentUser;

    public class ChildController : Controller
    {

        private readonly ISchoolServices schoolServices;
        private readonly IChildServices childServices;

        public ChildController(ISchoolServices _schoolServices, IChildServices _childServices)
        {
            schoolServices = _schoolServices;
            childServices = _childServices;
        }


        public async Task<IActionResult> All()
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (userId == null)
            {
                throw new ArgumentException(InvalidParentUserId);
            }

            var model = await childServices.GetAllMyChildrenAsync(userId);

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var model = new AddChildViewModel()
            {
                Schools = await schoolServices.GetSchoolsAsync()
            };

            Console.WriteLine();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddChildViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {

                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await childServices.AddChildAsync(model, userId);


                return RedirectToAction(nameof(All));

            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, InvalidChildUserId);

                return View(model);
            }

            
        }
    }
}
