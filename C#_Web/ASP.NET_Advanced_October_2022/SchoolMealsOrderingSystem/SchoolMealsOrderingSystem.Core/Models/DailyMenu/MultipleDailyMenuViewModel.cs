namespace SchoolMealsOrderingSystem.Core.Models.DailyMenu
{
    using SchoolMealsOrderingSystem.Core.Models.Child;

    public class MultipleDailyMenuViewModel
    {

        public IEnumerable<DailyMenuViewModel> DailyMenus { get; set; } = Enumerable.Empty<DailyMenuViewModel>();

        public ChildViewModel ChildViewModel { get; set; } = new ChildViewModel();

    }
}
