﻿namespace SchoolMealsOrderingSystem.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using Core.Models.Child;
    using Data;
    using Data.Entities;
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
                .Where(su => su.Id == schoolUserId && !su.IsDeleted)
                .Select(su => su.SchoolChildren.Where(sc => sc.IsDeleted == false)
                                               .Select(c => new ChildViewModel
                                               {
                                                   Id= c.Id,
                                                   FirstName = c.FirstName,
                                                   LastName = c.LastName,
                                                   YearsOld = c.YearsOld,
                                                   ImageUrl = c.ImageUrl,
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
