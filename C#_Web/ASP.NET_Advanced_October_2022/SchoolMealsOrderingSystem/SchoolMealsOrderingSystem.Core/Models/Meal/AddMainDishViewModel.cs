namespace SchoolMealsOrderingSystem.Core.Models.Meal
{
    using static Data.Constants.MainDishConstants;
    using static Data.Constants.GeneralConstants;
    using System.ComponentModel.DataAnnotations;

    public class AddMainDishViewModel
    {
        [Required(ErrorMessage = NameRequired)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = FieldSymbolsLength)]
        public string Name { get; set; } = null!;

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = FieldSymbolsLength)]
        public string? Description { get; set; }

        [Required(ErrorMessage = IngredientsRequired)]
        [StringLength(IngredientsMaxLength, MinimumLength = IngredientsMinLength)]
        public string Ingredients { get; set; } = null!;

        [Required(ErrorMessage = AllergensRequired)]
        [StringLength(AllergensMaxLength, MinimumLength = AllergensMinLength, ErrorMessage = FieldSymbolsLength)]
        public string Allergens { get; set; } = null!;
    }
}
