namespace SchoolMealsOrderingSystem.Data.Entities
{
    using SchoolMealsOrderingSystem.Data.Entities.Meals;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Constants.SchoolUserConstants;


    public class SchoolUser : ApplicationUser
    {

        public SchoolUser()
            : base()
        {
            SchoolChildren = new HashSet<Child>();
            Soups = new HashSet<Soup>();
            MainDishes = new HashSet<MainDish>();
            Desserts = new HashSet<Dessert>();
        }

        [MaxLength(SchoolNameMaxLength)]
        public string SchoolName { get; set; } = null!;


        public virtual ICollection<Child> SchoolChildren { get; set; }

        [NotMapped]
        public virtual ICollection<Soup> Soups { get; set; }
        [NotMapped]
        public virtual ICollection<MainDish> MainDishes { get; set; }
        [NotMapped]
        public virtual ICollection<Dessert> Desserts { get; set; }

    }

}

