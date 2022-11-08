namespace SchoolMealsOrderingSystem.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SchoolMealsOrderingSystem.Core.Contracts;
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

        public async Task<IEnumerable<ApplicationUser>> GetSchoolsAsync()
        {
            var result =  await schoolMealsOrderingSystemDbContext.Users.Where(u => u.IsSchool && !u.IsDeleted).ToListAsync();

            return result;
        }
    }
}
