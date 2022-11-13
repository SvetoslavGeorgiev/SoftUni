namespace SchoolMealsOrderingSystem.Core.Models.Child
{
    using Data.Entities;
    using System.ComponentModel.DataAnnotations;
    using static Data.Constants.DataConstants.Child;

    public class AddChildViewModel
    {
        [Required(ErrorMessage = "Полето \"Име\" е задължително")]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = ErrorMassageForTheLengthOfTheField)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Полето \"Фамилия\" е задължително")]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = ErrorMassageForTheLengthOfTheField)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Полето \"Връзката ви с детето\" е задължително")]
        [StringLength(RelationToChildMaxLength, MinimumLength = RelationToChildMinLength, ErrorMessage = ErrorMassageForTheLengthOfTheField)]
        public string RelationToChild { get; set; } = null!;

        [Required(ErrorMessage = "Полето \"Дата на раждане\" е задължително")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Полето \"Клас в училище\" е задължително")]
        [StringLength(YearInSchoolMaxLength, MinimumLength = YearInSchoolMinLength, ErrorMessage = ErrorMassageForTheLengthOfTheField)]
        public string YearInSchool { get; set; } = null!;


        public string SchoolUserId { get; set; } = null!;

        public IEnumerable<SchoolUser> Schools = new HashSet<SchoolUser>();

    }
}
