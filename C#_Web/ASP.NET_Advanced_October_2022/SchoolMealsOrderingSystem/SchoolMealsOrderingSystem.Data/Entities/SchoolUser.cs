namespace SchoolMealsOrderingSystem.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Constants.DataConstants.SchoolUser;


    public class SchoolUser : ApplicationUser
    {

        public SchoolUser()
            : base()
        {

        }

        [MaxLength(SchoolUserMaxLength)]
        public string SchoolName { get; set; }


        public ICollection<ParentUser> SchoolChildren { get; set; } = new HashSet<ParentUser>();

    }

}

