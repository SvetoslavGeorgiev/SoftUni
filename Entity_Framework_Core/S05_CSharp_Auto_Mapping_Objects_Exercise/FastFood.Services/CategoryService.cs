namespace FastFood.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FastFood.Data;
    using FastFood.Models;
    using FastFood.Services.Interfaces;
    using FastFood.Services.Models.Categories;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class CategoryService : ICategoryService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public CategoryService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task Add(CreateCategoryDto dto)
        {
            Category category = this.mapper.Map<Category>(dto);

            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<ListCategoryDto>> GetAll()
        {
            ICollection<ListCategoryDto> result = await this.dbContext
                .Categories
                .ProjectTo<ListCategoryDto>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();

            return result;
        }
    }
}