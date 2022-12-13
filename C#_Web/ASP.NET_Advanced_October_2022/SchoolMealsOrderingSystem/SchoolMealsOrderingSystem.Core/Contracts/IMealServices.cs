namespace SchoolMealsOrderingSystem.Core.Contracts
{
    using SchoolMealsOrderingSystem.Core.Models.Meal;
    using SchoolMealsOrderingSystem.Data.Entities.Meals;

    public interface IMealServices
    {

        Task<IEnumerable<Soup>> GetSoupsAsync();
        Task<IEnumerable<MainDish>> GetMainDishsAsync();
        Task<IEnumerable<Dessert>> GetDessertsAsync();

        Task<Soup> FindSoupAsync(Guid Id);
        Task<MainDish> FindMainDishAsync(Guid Id);
        Task<Dessert> FindDessertAsync(Guid Id);

        Task AddSoupAsync(AddSoupViewModel model);
        Task AddMealsAsync(AddMealsToSchoolListViewModel model, string userId);
    }
}
