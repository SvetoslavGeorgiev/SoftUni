namespace SchoolMealsOrderingSystem.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Constants.SchoolUserConstants;


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

    }

}

