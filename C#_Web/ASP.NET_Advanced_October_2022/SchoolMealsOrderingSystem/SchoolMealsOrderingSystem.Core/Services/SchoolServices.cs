namespace SchoolMealsOrderingSystem.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SchoolMealsOrderingSystem.Core.Contracts;
    using SchoolMealsOrderingSystem.Core.Models.Child;
    using SchoolMealsOrderingSystem.Data;
    using SchoolMealsOrderingSystem.Data.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SchoolServices : ISchoolServices
    {
        private readonly SchoolMealsOrderingSystemDbContext schoolMealsOrderingSystemDbContext;

        public SchoolServices(SchoolMealsOrderingSystemDbContext _schoolMealsOrderingSystemDbContext)
        {
            schoolMealsOrderingSystemDbContext = _schoolMealsOrderingSystemDbContext;
        }



        public async Task<IEnumerable<ChildViewModel>> GetAllChildrenInSelectedSchoolAsync(string schoolUserId)
        {
            return await schoolMealsOrderingSystemDbContext
                .SchoolUsers
                .Where(su => su.Id == schoolUserId)
                .Select(su => su.SchoolChildren.Where(sc => sc.IsDeleted == false)
                                               .Select(c => new ChildViewModel
                                               {
                                                   Id= c.Id,
                                                   FirstName = c.FirstName,
                                                   LastName = c.LastName,
                                                   YearsOld = c.YearsOld,
                                                   YearInSchool= c.YearInSchool,
                                                   MonthsOld = c.Months == 12 ? 0 : c.Months,
                                                   School = c.SchoolUser.SchoolName
                                               
                                               }))
                .SingleAsync();

        }

        public async Task<IEnumerable<SchoolUser>> GetSchoolsAsync()
        {
            var result =  await schoolMealsOrderingSystemDbContext
                .SchoolUsers
                .Where(u => u.IsSchool && !u.IsDeleted)
                .ToListAsync();

            return result;
        }
    }
}
