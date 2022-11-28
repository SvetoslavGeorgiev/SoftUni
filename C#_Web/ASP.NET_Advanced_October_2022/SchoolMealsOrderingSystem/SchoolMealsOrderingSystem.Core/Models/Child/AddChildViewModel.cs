namespace SchoolMealsOrderingSystem.Core.Models.Child
{
    using Data.Entities;
    using System.ComponentModel.DataAnnotations;
    using static Data.Constants.ChildConstants;
    using static Data.Constants.GeneralConstants;

    public class AddChildViewModel
    {
        [Required(ErrorMessage = NameRequired)]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = FieldSymbolsLength)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = LastNameRequired)]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = FieldSymbolsLength)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = ParentChildRelationRequired)]
        [StringLength(RelationToChildMaxLength, MinimumLength = RelationToChildMinLength, ErrorMessage = FieldSymbolsLength)]
        public string RelationToChild { get; set; } = null!;

        [Required(ErrorMessage = BirthDayRequired)]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = YearInSchoolRequired)]
        [StringLength(YearInSchoolMaxLength, MinimumLength = YearInSchoolMinLength, ErrorMessage = FieldSymbolsLength)]
        public string YearInSchool { get; set; } = null!;

        [Required(ErrorMessage = SchoolNameRequired)]
        public string SchoolUserId { get; set; } = null!;

        public IEnumerable<SchoolUser> Schools = new HashSet<SchoolUser>();

    }
}
