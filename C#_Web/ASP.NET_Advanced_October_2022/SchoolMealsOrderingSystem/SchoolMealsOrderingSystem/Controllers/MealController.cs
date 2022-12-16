namespace SchoolMealsOrderingSystem.Controllers
{
    using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
    using DocumentFormat.OpenXml.Spreadsheet;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SchoolMealsOrderingSystem.Core.Contracts;
    using SchoolMealsOrderingSystem.Core.Models.Child;
    using SchoolMealsOrderingSystem.Core.Models.Meal;
    using SchoolMealsOrderingSystem.Core.Services;
    using System.Security.Claims;
    using static Data.Constants.RoleConstants;
    using static Data.Constants.SchoolUserConstants;
    using static Data.Constants.SoupConstants;
    using static Data.Constants.MainDishConstants;
    using static Data.Constants.DessertConstatnts;

    [Authorize]
    public class MealController : Controller
    {
        private readonly IMealServices mealServices;

        public MealController(IMealServices _mealServices)
        {
            mealServices = _mealServices;
        }

        [HttpGet]
        [Authorize(Roles = School)]
        public IActionResult AddSoup()
        {

            var model = new AddSoupViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = School)]
        public async Task<IActionResult> AddSoup(AddSoupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string schoolUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {


                await mealServices.AddSoupAsync(model, schoolUserId);


                return RedirectToAction(nameof(AllSoups));

            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, InvalidSchoolUserId);

                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = School)]
        public IActionResult AddMainDish()
        {

            var model = new AddMainDishViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = School)]
        public async Task<IActionResult> AddMainDish(AddMainDishViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string schoolUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {


                await mealServices.AddMainDishAsync(model, schoolUserId);


                return RedirectToAction(nameof(AllMainDishes));

            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, InvalidSchoolUserId);

                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = School)]
        public IActionResult AddDessert()
        {

            var model = new AddDessertViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = School)]
        public async Task<IActionResult> AddDessert(AddDessertViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string schoolUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {


                await mealServices.AddDessertAsync(model, schoolUserId);


                return RedirectToAction(nameof(AllDesserts));

            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, InvalidSchoolUserId);

                return View(model);
            }
        }


        [HttpGet]
        [Authorize(Roles = School)]
        public async Task<IActionResult> AddMealsToSchoolList()
        {

            string schoolUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = new AddMealsToSchoolListViewModel
            {
                Soups = await mealServices.GetSoupsAsync(schoolUserId),
                MainDishes = await mealServices.GetMainDishsAsync(schoolUserId),
                Desserts = await mealServices.GetDessertsAsync(schoolUserId)
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = School)]
        public async Task<IActionResult> AddMealsToSchoolList(AddMealsToSchoolListViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            try
            {

                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


                await mealServices.AddMealsAsync(model, userId);


                return RedirectToAction("Index", "Home", new { area = SchoolAreaName });

            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, InvalidSchoolUserId);

                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = SchoolAndParent)]
        public async Task<IActionResult> AllSoups(string schoolId)
        {



            IEnumerable<SoupViewModel> model;

            if (schoolId != null)
            {
                model = await mealServices.GetSoupViewModelAsync(schoolId);
            }
            else
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                model = await mealServices.GetSoupViewModelAsync(userId);
            }


            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = SchoolAndParent)]
        public async Task<IActionResult> AllMainDishes(string schoolId)
        {

            IEnumerable<MainDishViewModel> model;

            
            if (schoolId != null)
            {
                model = await mealServices.GetMainDishViewModelAsync(schoolId);
            }
            else
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                model = await mealServices.GetMainDishViewModelAsync(userId);
            }


            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = SchoolAndParent)]
        public async Task<IActionResult> AllDesserts(string schoolId)
        {

            
            IEnumerable<DessertViewModel> model;


            if (schoolId != null)
            {
                model = await mealServices.GetDessertViewModelAsync(schoolId);
            }
            else
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                model = await mealServices.GetDessertViewModelAsync(userId);
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = School)]
        public async Task<IActionResult> EditSoup(Guid soupId)
        {

            var soup = await mealServices.GetSoupForEditAsync(soupId);

            if (soup == null)
            {
                return RedirectToAction(nameof(AllSoups));
            }

            return View(soup);
        }


        [HttpPost]
        [Authorize(Roles = School)]
        public async Task<IActionResult> EditSoup(EditSoupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {

                await mealServices.EditSoupAsync(model);


                return RedirectToAction(nameof(AllSoups));

            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, InvalidSoupId);

                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = School)]
        public async Task<IActionResult> EditMainDish(Guid mainDishId)
        {

            var mainDish = await mealServices.GetMainDishForEditAsync(mainDishId);

            if (mainDish == null)
            {
                return RedirectToAction(nameof(AllMainDishes));
            }

            return View(mainDish);
        }


        [HttpPost]
        [Authorize(Roles = School)]
        public async Task<IActionResult> EditMainDish(EditMainDishViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {

                await mealServices.EditMainDishAsync(model);


                return RedirectToAction(nameof(AllMainDishes));

            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, InvalidMainDishId);

                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = School)]
        public async Task<IActionResult> EditDessert(Guid dessertId)
        {

            var dessert = await mealServices.GetDessertForEditAsync(dessertId);

            if (dessert == null)
            {
                return RedirectToAction(nameof(AllDesserts));
            }

            return View(dessert);
        }


        [HttpPost]
        [Authorize(Roles = School)]
        public async Task<IActionResult> EditDessert(EditDessertViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {

                await mealServices.EditDessertAsync(model);


                return RedirectToAction(nameof(AllDesserts));

            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, InvalidDessertId);

                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSoup(Guid soupId)
        {

            await mealServices.DeleteSoupAsync(soupId);

            return RedirectToAction(nameof(AllSoups));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMainDish(Guid mainDishId)
        {

            await mealServices.DeleteMainDishAsync(mainDishId);

            return RedirectToAction(nameof(AllMainDishes));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDessert(Guid dessertId)
        {

            await mealServices.DeleteDessertAsync(dessertId);

            return RedirectToAction(nameof(AllDesserts));
        }

    }
}
