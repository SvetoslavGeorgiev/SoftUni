namespace SchoolMealsOrderingSystem.Core.Models.Child
{
    using System.ComponentModel.DataAnnotations;

    public class ChildViewModel
    {

        [UIHint("hidden")]
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public int YearsOld { get; set; }

        public int MonthsOld { get; set; }

        public string YearInSchool { get; set; } = null!;

        public string School { get; set; } = null!;

    }
}
