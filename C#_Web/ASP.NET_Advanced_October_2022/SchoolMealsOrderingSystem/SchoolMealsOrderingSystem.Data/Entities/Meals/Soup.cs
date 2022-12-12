namespace SchoolMealsOrderingSystem.Data.Entities.Meals
{
    using Data.Interfaces;
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Constants.GeneralConstants;
    using static Constants.SoupConstants;

    public class Soup : IsDeletable
    {

        public Soup()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = NameRequired)]
        [MaxLength(SoupNameMaxLength)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Required(ErrorMessage = IngredientsRequired)]
        [MaxLength(IngredientsMaxLength)]
        public string Ingredients { get; set; } = null!;

        [Required(ErrorMessage = AllergensRequired)]
        [MaxLength(AllergensMaxLength)]
        public string Allergens { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
