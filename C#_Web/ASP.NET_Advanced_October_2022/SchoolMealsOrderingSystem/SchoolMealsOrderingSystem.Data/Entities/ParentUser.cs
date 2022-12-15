namespace SchoolMealsOrderingSystem.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using static Constants.ParentUserConstants;

    public class ParentUser : ApplicationUser
    {

        public ParentUser()
            : base()
        {
            ParentsChildren = new HashSet<ParentChild>();
        }


        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// https://www.guinnessworldrecords.com/world-records/67285-longest-personal-name -> Longest personal name by Guinness Total(774), lastName(597)
        /// </summary>
        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;


        public virtual ICollection<ParentChild> ParentsChildren { get; set; }



    }
}
