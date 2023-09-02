namespace SchoolMealsOrderingSystem.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SchoolMealsOrderingSystem.Core.Contracts;
    using SchoolMealsOrderingSystem.Core.Models.Child;
    using System.Security.Claims;
    using static Data.Constants.ChildConstants;
    using static Data.Constants.ParentUserConstants;
    using static Data.Constants.RoleConstants;

    [Authorize(Roles = Parent)]
    public class ChildController : Controller
    {

        private readonly ISchoolServices schoolServices;
        private readonly IChildServices childServices;
        private readonly IImageService imageService;

        public ChildController(ISchoolServices _schoolServices, IChildServices _childServices, IImageService _imageService)
        {
            schoolServices = _schoolServices;
            childServices = _childServices;
            imageService = _imageService;
        }

        [HttpGet]
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


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddChildViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var file = model.ImageUrl;

            var maxSize = 3.2 * 1024 * 1024;

            if (file.Length > maxSize)
            {
                ModelState.AddModelError(string.Empty, InvalidChildImageSize);

                return View(model);
            }
            try
            {
                
                var name = $"{model.FirstName}_{model.LastName}";

                var imageUrl = await imageService.UploadImageToAwsS3(name, file);


                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


                await childServices.AddChildAsync(model, userId, imageUrl);


                return RedirectToAction(nameof(All));

            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, InvalidChildUserId);

                return View(model);
            }


        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid childId)
        {

            var child = await childServices.GetChildModelForEditAsync(childId);

            if (child == null)
            {
                return RedirectToAction(nameof(All));
            }

            child.Schools = await schoolServices.GetSchoolsAsync();

            return View(child);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditChildViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {

                await childServices.EditChildAsync(model);


                return RedirectToAction(nameof(All));

            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, InvalidChildUserId);

                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {

            await childServices.DeleteChildAsync(id);

            return RedirectToAction(nameof(All));


        }
    }
}
