namespace SchoolMealsOrderingSystem.Core.Models.Meal
{
    
    using SchoolMealsOrderingSystem.Data.Entities.Meals;
    using SchoolMealsOrderingSystem.Data.Entities.Menu;
    using System.ComponentModel.DataAnnotations;
    using static Data.Constants.GeneralConstants;

    public class MealsForParentToChooseViewModel
    {
        public MealsForParentToChooseViewModel()
        {
            Soups = new List<Soup>();
            MainDishes = new List<MainDish>();
            Desserts= new List<Dessert>();
            DailyMenus = new List<DailyMenu>();
        }

        public DayOfWeek DayOfTheWeek { get; set; }
        public Guid ChildId { get; set; }
        public Guid SoupId { get; set; }
        public Guid MainDishId { get; set; }
        public Guid DessertsId { get; set; }

        [UIHint(Hidden)]
        public string SchoolId { get; set; } = null!;

        public IEnumerable<Soup> Soups { get; set; }
        public IEnumerable<MainDish> MainDishes { get; set; }
        public IEnumerable<Dessert> Desserts { get; set; }
        public IEnumerable<DailyMenu> DailyMenus { get; set; }

    }
}
