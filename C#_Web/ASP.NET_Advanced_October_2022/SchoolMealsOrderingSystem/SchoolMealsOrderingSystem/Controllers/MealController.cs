namespace SchoolMealsOrderingSystem.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SchoolMealsOrderingSystem.Core.Contracts;
    using SchoolMealsOrderingSystem.Core.Models.Meal;
    using System.Security.Claims;
    using static Data.Constants.RoleConstants;
    using static Data.Constants.SchoolUserConstants;

    [Authorize]
    public class MealController : Controller
    {
        private readonly IMealServices mealServices;

        public MealController(IMealServices _mealServices)
        {
            mealServices= _mealServices;
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
        [Authorize(Roles = "School, Parent")]
        public async Task<IActionResult> AllSoups()
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (userId == null)
            {
                throw new ArgumentException(InvalidSchoolUserId);
            }

            var model = await mealServices.GetSoupViewModelAsync(userId);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "School, Parent")]
        public async Task<IActionResult> AllMainDishes()
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (userId == null)
            {
                throw new ArgumentException(InvalidSchoolUserId);
            }

            var model = await mealServices.GetMainDishViewModelAsync(userId);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "School, Parent")]
        public async Task<IActionResult> AllDesserts()
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (userId == null)
            {
                throw new ArgumentException(InvalidSchoolUserId);
            }

            var model = await mealServices.GetDessertViewModelAsync(userId);

            return View(model);
        }
    }
}
