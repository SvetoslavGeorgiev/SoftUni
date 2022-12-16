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

    }

}

