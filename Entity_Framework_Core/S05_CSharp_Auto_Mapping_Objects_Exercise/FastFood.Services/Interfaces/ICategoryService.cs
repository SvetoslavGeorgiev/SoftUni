namespace FastFood.Services.Interfaces
{
    using FastFood.Services.Models.Categories;

    public interface ICategoryService
    {

        Task Add(CreateCategoryDto dto);


        Task<ICollection<ListCategoryDto>> GetAll();
    }
}
