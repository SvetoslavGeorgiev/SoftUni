namespace SchoolMealsOrderingSystem.Core.Contracts
{
    using SchoolMealsOrderingSystem.Core.Models.DailyMenu;
    using SchoolMealsOrderingSystem.Core.Models.Meal;
    using SchoolMealsOrderingSystem.Data.Entities;

    public interface IDailyMenuServices
    {
        Task<MealsForParentToChooseViewModel> GetMealsForParentsToChoose(Guid id);

        Task AddDailyMenuAsync(MealsForParentToChooseViewModel model);

        Task<IEnumerable<DailyMenuViewModel>> GetAllDailyMenusAsync(Guid childId);

        Task DeleteDailyMenuAsync (Guid dailyMenuId);

    }
}
