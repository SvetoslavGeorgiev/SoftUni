namespace SchoolMealsOrderingSystem.Core.Models.Meal
{
    
    using SchoolMealsOrderingSystem.Data.Entities.Meals;

    public class AddMealsToSchoolListViewModel
    {

        public AddMealsToSchoolListViewModel()
        {
            Soups = new HashSet<Soup>();
            MainDishes = new HashSet<MainDish>();
            Desserts = new HashSet<Dessert>();
        }

        public Guid FirstSoupId { get; set; }
        public Guid SecondSoupId { get; set; }
        public Guid ThirdSoupId { get; set; }
        public Guid FirstMainDishId { get; set; }
        public Guid SecondMainDishId { get; set; }
        public Guid ThirdMainDishId { get; set; }
        public Guid FirstDessertsId { get; set; }
        public Guid SecondDessertsId { get; set; }
        public Guid ThirdDessertsId { get; set; }

        public IEnumerable<Soup> Soups { get; set; }
        public IEnumerable<MainDish> MainDishes { get; set; }
        public IEnumerable<Dessert> Desserts { get; set; }

    }
}
