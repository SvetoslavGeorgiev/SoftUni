namespace SchoolMealsOrderingSystem.Data.Entities.Menu
{
    using Meals;
    using Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DailyMenu : IsDeletable
    {

        public DailyMenu()
        {
            IsDeleted = false;
            Id= Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Name is the name of the day of the week
        /// </summary>
        [Required]
        public DayOfWeek Name { get; set; }

        [Required]
        [ForeignKey(nameof(Soup))]
        public Guid SoupId { get; set; }

        public Soup? Soup { get; set; }

        [Required]
        [ForeignKey(nameof(MainDish))]
        public Guid MainDishId { get; set; }

        public MainDish? MainDish { get; set; }


        [Required]
        [ForeignKey(nameof(Dessert))]
        public Guid DessertId { get; set; }

        public Dessert? Dessert { get; set; }



        public bool IsDeleted { get; set; }


        [Required]
        public DateTime CreatedOn { get; set; }


        [Required]
        [ForeignKey(nameof(Child))]
        public Guid ChildId { get; set; }

        public Child? Child { get; set; }
    }
}
