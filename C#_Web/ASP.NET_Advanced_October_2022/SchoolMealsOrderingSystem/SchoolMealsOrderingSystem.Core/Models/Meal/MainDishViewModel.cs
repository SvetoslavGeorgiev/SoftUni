namespace SchoolMealsOrderingSystem.Core.Models.Meal
{
    using System.ComponentModel.DataAnnotations;

    public class MainDishViewModel
    {

        [UIHint("hidden")]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Ingredients { get; set; } = null!;
        public string Allergens { get; set; } = null!;

    }
}
