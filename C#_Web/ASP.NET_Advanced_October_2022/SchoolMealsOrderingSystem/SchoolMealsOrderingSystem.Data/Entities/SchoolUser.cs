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
            SoupsForParents = new HashSet<Soup>();
            MainDishesForParents = new HashSet<MainDish>();
            DessertsForParents = new HashSet<Dessert>();
        }

        [MaxLength(SchoolNameMaxLength)]
        public string SchoolName { get; set; } = null!;


        public virtual ICollection<Child> SchoolChildren { get; set; }

        [InverseProperty(nameof(Soup.SchoolUser))]
        public virtual ICollection<Soup> Soups { get; set; }

        [InverseProperty(nameof(MainDish.SchoolUser))]
        public virtual ICollection<MainDish> MainDishes { get; set; }

        [InverseProperty(nameof(Dessert.SchoolUser))]
        public virtual ICollection<Dessert> Desserts { get; set; }



        [NotMapped]
        public virtual ICollection<Soup> SoupsForParents { get; set; }
        [NotMapped]
        public virtual ICollection<MainDish> MainDishesForParents { get; set; }
        [NotMapped]
        public virtual ICollection<Dessert> DessertsForParents { get; set; }

    }

}

