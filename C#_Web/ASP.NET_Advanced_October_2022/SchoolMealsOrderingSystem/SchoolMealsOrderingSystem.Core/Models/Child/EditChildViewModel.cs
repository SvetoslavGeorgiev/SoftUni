namespace SchoolMealsOrderingSystem.Core.Models.Child
{
    using SchoolMealsOrderingSystem.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.Constants.ChildConstants;
    using static Data.Constants.GeneralConstants;

    public class EditChildViewModel
    {

        [UIHint(Hidden)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = NameRequired)]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = FieldSymbolsLength)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = LastNameRequired)]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = FieldSymbolsLength)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = ParentChildRelationRequired)]
        [StringLength(RelationToChildMaxLength, MinimumLength = RelationToChildMinLength, ErrorMessage = FieldSymbolsLength)]
        public string RelationToChild { get; set; } = null!;

        [Required(ErrorMessage = ImageUrlRequired)]
        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength, ErrorMessage = FieldSymbolsLength)]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = BirthDayRequired)]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = YearInSchoolRequired)]
        [StringLength(YearInSchoolMaxLength, MinimumLength = YearInSchoolMinLength, ErrorMessage = FieldSymbolsLength)]
        public string YearInSchool { get; set; } = null!;


        public string SchoolUserId { get; set; } = null!;

        public IEnumerable<ApplicationUser> Schools = new HashSet<ApplicationUser>();
    }
}
