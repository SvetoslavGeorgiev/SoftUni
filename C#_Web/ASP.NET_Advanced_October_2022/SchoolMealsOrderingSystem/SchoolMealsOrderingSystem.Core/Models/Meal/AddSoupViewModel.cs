namespace SchoolMealsOrderingSystem.Core.Models.Meal
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Constants.SoupConstants;
    using static Data.Constants.GeneralConstants;

    public class AddSoupViewModel
    {
        [Required(ErrorMessage = NameRequired)]
        [StringLength(SoupNameMaxLength, MinimumLength = SoupNameMinLength, ErrorMessage = FieldSymbolsLength)]
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
