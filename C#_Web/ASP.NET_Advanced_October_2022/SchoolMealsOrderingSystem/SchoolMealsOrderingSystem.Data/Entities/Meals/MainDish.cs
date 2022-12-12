namespace SchoolMealsOrderingSystem.Data.Entities.Meals
{
    using Interfaces;
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Constants.GeneralConstants;
    using static Constants.MainDishConstants;

    public class MainDish : IsDeletable
    {
        public MainDish()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = NameRequired)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; } = null!;

        [Required(ErrorMessage = IngredientsRequired)]
        [MaxLength(IngredientsMaxLength)]
        public string Ingredients { get; set; } = null!;

        [Required(ErrorMessage = AllergensRequired)]
        [MaxLength(AllergensMaxLength)]
        public string Allergens { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
