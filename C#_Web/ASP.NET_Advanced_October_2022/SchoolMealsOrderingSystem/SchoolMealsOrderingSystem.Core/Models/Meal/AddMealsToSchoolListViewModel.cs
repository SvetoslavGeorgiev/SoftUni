namespace SchoolMealsOrderingSystem.Core.Models.Meal
{
    
    using SchoolMealsOrderingSystem.Data.Entities.Meals;
    using System.ComponentModel.DataAnnotations;

    public class AddMealsToSchoolListViewModel
    {

        public AddMealsToSchoolListViewModel()
        {
            Soups = new HashSet<Soup>();
            MainDishes = new HashSet<MainDish>();
            Desserts = new HashSet<Dessert>();
        }


        [Required]        
        public Guid FirstSoupId { get; set; }

        [Required]
        public Guid SecondSoupId { get; set; }

        [Required]
        public Guid ThirdSoupId { get; set; }

        [Required]
        public Guid FirstMainDishId { get; set; }

        [Required]
        public Guid SecondMainDishId { get; set; }

        [Required]
        public Guid ThirdMainDishId { get; set; }

        [Required]
        public Guid FirstDessertsId { get; set; }

        [Required]
        public Guid SecondDessertsId { get; set; }

        [Required]
        public Guid ThirdDessertsId { get; set; }

        public IEnumerable<Soup> Soups { get; set; }
        public IEnumerable<MainDish> MainDishes { get; set; }
        public IEnumerable<Dessert> Desserts { get; set; }

    }
}
