namespace WebShopDemo.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebShopDemo.Core.Constants;
    using WebShopDemo.Core.Contracts;
    using WebShopDemo.Core.Models;

    /// <summary>
    /// web shop products
    /// </summary>
    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            this.productService = _productService;
        }


        /// <summary>
        /// list of all products
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetAll();
            ViewData["Title"] = "Products";

            return View(products);
        }


        [HttpGet]
        [Authorize(Roles = $"{RoleConstants.Manager}, {RoleConstants.Supervisor}")]
        public IActionResult Add()
        {
            var model = new ProductDto();
            ViewData["Title"] = "Add new product";

            return View(model);
        }


        [HttpPost]
        [Authorize(Roles = $"{RoleConstants.Manager}, {RoleConstants.Supervisor}")]
        public async Task<IActionResult> Add(ProductDto model)
        {
            ViewData["Title"] = "Add new product";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await productService.Add(model);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [Authorize(Roles = RoleConstants.Supervisor)]
        public async Task<IActionResult> Delete(Guid id)
        {

            await productService.Delete(id);

            return RedirectToAction(nameof(Index));


        }

    }
}
