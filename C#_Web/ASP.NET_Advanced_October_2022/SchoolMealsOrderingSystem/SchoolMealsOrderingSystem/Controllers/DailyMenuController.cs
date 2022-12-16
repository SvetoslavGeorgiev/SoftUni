namespace SchoolMealsOrderingSystem.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SchoolMealsOrderingSystem.Core.Contracts;
    using SchoolMealsOrderingSystem.Core.Models.Meal;
    using static Data.Constants.RoleConstants;


    [Authorize]
    public class DailyMenuController : Controller
    {
        private readonly IDailyMenuServices menuServices;

        public DailyMenuController(IDailyMenuServices _menuServices)
        {
            menuServices = _menuServices;
        }


        [HttpGet]
        [Authorize(Roles = Parent)]
        public async Task<IActionResult> GetMealsForParentsToChoose(Guid childId)
        {

            var model = new MealsForParentToChooseViewModel();

            try
            {
                model = await menuServices.GetMealsForParentsToChoose(childId);
            }
            catch (ArgumentException ae)
            {
                ModelState.AddModelError(string.Empty, ae.Message);
                RedirectToAction(nameof(ChildController.All));
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = Parent)]
        public async Task<IActionResult> GetMealsForParentsToChoose(MealsForParentToChooseViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await menuServices.AddDailyMenuAsync(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                return View(model);
            }


        }

        [HttpGet]
        [Authorize(Roles = SchoolAndParent)]
        public async Task<IActionResult> All(Guid childId)
        {

            var model = await menuServices.GetAllDailyMenusAsync(childId);

            return View(model);
        }
    }
}
