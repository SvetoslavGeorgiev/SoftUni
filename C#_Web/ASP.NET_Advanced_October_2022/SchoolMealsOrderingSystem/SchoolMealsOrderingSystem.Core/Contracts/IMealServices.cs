namespace SchoolMealsOrderingSystem.Core.Contracts
{
    using SchoolMealsOrderingSystem.Core.Models.Child;
    using SchoolMealsOrderingSystem.Core.Models.Meal;
    using SchoolMealsOrderingSystem.Data.Entities;
    using SchoolMealsOrderingSystem.Data.Entities.Meals;

    public interface IMealServices
    {

        Task<IEnumerable<Soup>> GetSoupsAsync(string schoolUserId);
        Task<IEnumerable<MainDish>> GetMainDishsAsync(string schoolUserId);
        Task<IEnumerable<Dessert>> GetDessertsAsync(string schoolUserId);

        Task<IEnumerable<SoupViewModel>> GetSoupViewModelAsync(string schoolUserId);
        Task<IEnumerable<MainDishViewModel>> GetMainDishViewModelAsync(string schoolUserId);
        Task<IEnumerable<DessertViewModel>> GetDessertViewModelAsync(string schoolUserId);

        Task<Soup> FindSoupAsync(Guid Id);
        Task<MainDish> FindMainDishAsync(Guid Id);
        Task<Dessert> FindDessertAsync(Guid Id);

        Task AddSoupAsync(AddSoupViewModel model, string schoolUserId);

        Task AddMainDishAsync(AddMainDishViewModel model,string schoolUserId);

        Task AddDessertAsync(AddDessertViewModel model, string schoolUserId);
        Task AddMealsAsync(AddMealsToSchoolListViewModel model, string userId);

        Task DeleteSoupAsync(Guid Id);
        Task DeleteMainDishAsync(Guid Id);
        Task DeleteDessertAsync(Guid Id);

        Task GetRestOfMealsUnselected(List<Guid> selectedIdList, string id);

        Task<EditSoupViewModel> GetSoupForEditAsync(Guid soupId);
        Task EditSoupAsync(EditSoupViewModel editSoupViewModel);
        Task<EditMainDishViewModel> GetMainDishForEditAsync(Guid mainDishId);

        Task EditMainDishAsync(EditMainDishViewModel EditMainDishViewModel);
        //Task<EditSoupViewModel> GetDessertForEditAsync(Guid soupId);
    }
}
