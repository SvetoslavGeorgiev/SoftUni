namespace SchoolMealsOrderingSystem.Data.Entities.Meals
{
    using Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Constants.DessertConstatnts;
    using static Constants.GeneralConstants;

    public class Dessert : IsDeletable
    {
        public Dessert()
        {
            IsDeleted = false;
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; } = null!;

        [Required]
        [MaxLength(UrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(IngredientsMaxLength)]
        public string Ingredients { get; set; } = null!;

        [Required]
        [MaxLength(AllergensMaxLength)]
        public string Allergens { get; set; } = null!;

        public bool IsDeleted { get; set; }

        [Required]
        [ForeignKey(nameof(SchoolUser))]
        public string SchoolUserId { get; set; }

        public SchoolUser SchoolUser { get; set; }

    }
}
