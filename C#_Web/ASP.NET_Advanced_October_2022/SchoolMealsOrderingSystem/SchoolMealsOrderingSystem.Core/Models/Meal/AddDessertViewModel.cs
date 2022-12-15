namespace SchoolMealsOrderingSystem.Core.Models.Meal
{
    using static Data.Constants.DessertConstatnts;
    using static Data.Constants.GeneralConstants;
    using System.ComponentModel.DataAnnotations;

    public class AddDessertViewModel
    {

        [Required(ErrorMessage = NameRequired)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = FieldSymbolsLength)]
        public string Name { get; set; } = null!;

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = FieldSymbolsLength)]
        public string? Description { get; set; }

        [Required(ErrorMessage = IngredientsRequired)]
        [StringLength(IngredientsMaxLength, MinimumLength = IngredientsMinLength, ErrorMessage = FieldSymbolsLength)]
        public string Ingredients { get; set; } = null!;

        [Required(ErrorMessage = UrlRequired)]
        [StringLength(UrlMaxLength, MinimumLength = UrlMinLength, ErrorMessage = FieldSymbolsLength)]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = AllergensRequired)]
        [StringLength(AllergensMaxLength, MinimumLength = AllergensMinLength, ErrorMessage = FieldSymbolsLength)]
        public string Allergens { get; set; } = null!;
    }
}
