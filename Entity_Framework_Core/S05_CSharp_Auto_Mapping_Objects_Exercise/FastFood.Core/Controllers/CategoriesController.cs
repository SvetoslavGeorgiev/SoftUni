namespace FastFood.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using FastFood.Services.Interfaces;
    using FastFood.Services.Models.Categories;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoriesController(IMapper mapper , ICategoryService categoryService)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create", "Categories");
            }

            CreateCategoryDto categoryDto = this.mapper.Map<CreateCategoryDto>(model);
            await this.categoryService.Add(categoryDto);

            return this.RedirectToAction("All", "Categories");
        }

        public async Task<IActionResult> All()
        {
            ICollection<ListCategoryDto> categoryDtos = await this.categoryService.GetAll();  
            IList<CategoryAllViewModel> categoryAll = new List<CategoryAllViewModel>();

            foreach (var cDto in categoryDtos)
            {

                categoryAll.Add(this.mapper.Map<CategoryAllViewModel>(cDto));

            }

            return this.View(categoryAll);
        }
    }
}
