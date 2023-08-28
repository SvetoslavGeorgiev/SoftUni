namespace SchoolMealsOrderingSystem.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SchoolMealsOrderingSystem.Core.Contracts;
    using SchoolMealsOrderingSystem.Core.Models.Meal;
    using SchoolMealsOrderingSystem.Core.Models.DailyMenu;
    using static Data.Constants.RoleConstants;


    [Authorize]
    public class DailyMenuController : Controller
    {
        private readonly IDailyMenuServices menuServices;
        private readonly IChildServices childServices;

        public DailyMenuController(IDailyMenuServices _menuServices, IChildServices _childServices)
        {
            menuServices = _menuServices;
            childServices = _childServices;
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

                return RedirectToAction(nameof(All), new { childId = model.ChildId});
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                //return RedirectToAction("Error", "Home");

                return View(model);
            }


        }

        [HttpGet]
        [Authorize(Roles = SchoolAndParent)]
        public async Task<IActionResult> All(Guid childId)
        {

            var model = new MultipleDailyMenuViewModel();
            
            var menues = await menuServices.GetAllDailyMenusAsync(childId);
            var child = await childServices.GetChildByIdAsync(childId);

            model.DailyMenus = menues;
            model.ChildViewModel = child;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = Parent)]
        public async Task<IActionResult> Delete(Guid id)
        {

            await menuServices.DeleteDailyMenuAsync(id);

            return RedirectToAction("All", "Child");


        }
    }
}
