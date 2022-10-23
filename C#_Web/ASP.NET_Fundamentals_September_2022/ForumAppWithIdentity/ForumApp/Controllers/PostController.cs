namespace ForumApp.Controllers
{
    using ForumApp.Contracts;
    using ForumApp.Data.Entities;
    using ForumApp.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;

    [Authorize]
    public class PostController : Controller
    {

        private readonly IPostsService postsService;

        public PostController(IPostsService _postsService)
        {
            postsService = _postsService;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {

            if (!User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Login", "User");
            }

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var model = await postsService.GetAllAsync(userId);

            return View(model);
        }


        [HttpGet]
        public IActionResult Add()
        {

            var model = new PostViewModel();

            ViewData["Title"] = "Add new Post";

            return View("Edit", model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await postsService.GetModelForEditAsync(id);

            if (post != null)
            {
                return View(post);
            }

            return RedirectToAction(nameof(All));
        }


        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = model.Id == 0 ? "Add new Post" : "Edit Post";

                return View(model);
            }

            if (model.Id == 0)
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                await postsService.AddAsync(model, userId);
            }
            else
            {
                await postsService.EditAsync(model);
            }


            return RedirectToAction(nameof(All));
        }


        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            await postsService.DeleteAsync(id);

            return RedirectToAction(nameof(All));
        }
    }
}
