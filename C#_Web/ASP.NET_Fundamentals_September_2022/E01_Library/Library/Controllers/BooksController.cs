namespace Library.Controllers
{
    using Contracts;
    using Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using static Data.DataConstants.Book;
    using static Data.DataConstants.ControllerConstants;

    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookServices bookServices;

        public BooksController(IBookServices _bookServices)
        {
            bookServices = _bookServices;
        }


        public async Task<IActionResult> All()
        {
            var model = await bookServices.GetAllAsync();

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var model = new AddBookViewModel()
            {
               Categories  = await bookServices.GetCategoriesAsync()
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await bookServices.AddBookAsync(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, InvalidBook);

                return View(model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {

            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await bookServices.AddBookToCollectionAsync(bookId, userId);

            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
            return RedirectToAction(nameof(All));

        }

        [HttpGet]
        public async Task<IActionResult> AllMyBooks()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await bookServices.GetAllMyBooks(userId);
            

            return View("Mine", model);

        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await bookServices.RemoveBookFromCollectionAsync(bookId, userId);

            return RedirectToAction(nameof(AllMyBooks));
        }
    }
}
