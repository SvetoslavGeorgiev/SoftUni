namespace SchoolMealsOrderingSystem.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using static Constants.DataConstants.ParentUser;

    public class ParentUser : ApplicationUser
    {

        public ParentUser()
            : base()
        {

        }


        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// https://www.guinnessworldrecords.com/world-records/67285-longest-personal-name -> Longest personal name by Guinness Total(774), last(597)
        /// </summary>
        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;


        public virtual ICollection<ParentChild> ParentsChildren { get; set; } = new HashSet<ParentChild>();



    }
}
