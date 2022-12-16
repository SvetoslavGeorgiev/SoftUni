namespace SchoolMealsOrderingSystem.Data.Entities.Meals
{
    using Data.Interfaces;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Constants.SoupConstants;

    public class Soup : IsDeletable
    {

        public Soup()
        {
            IsDeleted = false;
            Id = Guid.NewGuid();
            IsSelected = false;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(SoupNameMaxLength)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        [MaxLength(IngredientsMaxLength)]
        public string Ingredients { get; set; } = null!;

        [Required]
        [MaxLength(AllergensMaxLength)]
        public string Allergens { get; set; } = null!;

        [Required]
        [MaxLength(UrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        public bool IsDeleted { get; set; }

        /// <summary>
        /// if IsSelected is true this means the soup is been selected for offering to the parent
        /// </summary>
        public bool IsSelected { get; set; }

        [Required]
        [ForeignKey(nameof(SchoolUser))]
        public string SchoolUserId { get; set; } = null!;

        public SchoolUser? SchoolUser { get; set; }
    }
}
