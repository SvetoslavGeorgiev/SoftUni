namespace SchoolMealsOrderingSystem.Data.Entities.Meals
{
    using Interfaces;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Constants.GeneralConstants;
    using static Constants.MainDishConstants;

    public class MainDish : IsDeletable
    {
        public MainDish()
        {
            IsDeleted = false;
            Id = Guid.NewGuid();
            IsSelected = false;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength]
        public string? Description { get; set; } = null!;

        [Required]
        [MaxLength(IngredientsMaxLength)]
        public string Ingredients { get; set; } = null!;

        [Required]
        [MaxLength(AllergensMaxLength)]
        public string Allergens { get; set; } = null!;

        public bool IsDeleted { get; set; }

        /// <summary>
        /// if IsSelected is true this means the main dish is been selected for offering to the parent
        /// </summary>
        public bool IsSelected { get; set; }

        [Required]
        [ForeignKey(nameof(SchoolUser))]
        public string SchoolUserId { get; set; }

        public SchoolUser SchoolUser { get; set; }

        [Required]
        [MaxLength(UrlMaxLength)]
        public string ImageUrl { get; set; } = null!;
    }
}
