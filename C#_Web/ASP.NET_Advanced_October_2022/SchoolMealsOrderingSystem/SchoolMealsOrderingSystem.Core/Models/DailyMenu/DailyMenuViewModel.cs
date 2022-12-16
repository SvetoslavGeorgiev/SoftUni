namespace SchoolMealsOrderingSystem.Core.Models.DailyMenu
{
    using SchoolMealsOrderingSystem.Data.Entities.Meals;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using static Data.Constants.GeneralConstants;

    public class DailyMenuViewModel
    {
        [UIHint(Hidden)]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Soup Soup { get; set; } = null!;

        public MainDish? MainDish { get; set; } = null!;

        public Dessert? Dessert { get; set; } = null!;

    }
}
