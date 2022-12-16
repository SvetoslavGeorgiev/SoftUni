namespace SchoolMealsOrderingSystem.Core.Models.Meal
{
    using SchoolMealsOrderingSystem.Data.Entities.Meals;

    public class MealsForParentToChooseViewModel
    {
        public MealsForParentToChooseViewModel()
        {
            Soups = new List<Soup>();
            MainDishes = new List<MainDish>();
            Desserts= new List<Dessert>();
        }

        public DayOfWeek DayOfTheWeek { get; set; }
        public Guid ChildId { get; set; }
        public Guid SoupId { get; set; }
        public Guid MainDishId { get; set; }
        public Guid DessertsId { get; set; }
        public string SchoolId { get; set; } = null!;

        public IEnumerable<Soup> Soups { get; set; }
        public IEnumerable<MainDish> MainDishes { get; set; }
        public IEnumerable<Dessert> Desserts { get; set; }

    }
}
