namespace SchoolMealsOrderingSystem.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SchoolMealsOrderingSystem.Core.Contracts;
    using SchoolMealsOrderingSystem.Core.Models.Child;
    using SchoolMealsOrderingSystem.Data;
    using SchoolMealsOrderingSystem.Data.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static Data.Constants.DataConstants.ParentUser;

    public class ChildServices : IChildServices
    {
        private readonly SchoolMealsOrderingSystemDbContext schoolMealsOrderingSystemDbContext;

        public ChildServices(SchoolMealsOrderingSystemDbContext _schoolMealsOrderingSystemDbContext)
        {
            schoolMealsOrderingSystemDbContext = _schoolMealsOrderingSystemDbContext;
        }

        public async Task AddChildAsync(AddChildViewModel AddChildViewModel, string userId)
        {
            var user = await schoolMealsOrderingSystemDbContext
                .Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();


            if (user == null)
            {
                throw new ArgumentException(InvalidParentUserId);
            }


            var child = new Child()
            {
                FirstName = AddChildViewModel.FirstName,
                LastName = AddChildViewModel.LastName,
                Birthday = AddChildViewModel.Birthday,
                SchoolId = AddChildViewModel.SchoolId,
                ParentChildRelation = AddChildViewModel.RelationToChild
            };


            child.ParentsChildren.Add((ParentUser)user);

            await schoolMealsOrderingSystemDbContext.Children.AddAsync(child);

            await schoolMealsOrderingSystemDbContext.ParentChild.AddAsync(new ParentChild
            {
                ChildId = child.Id,
                ParentUserId = userId
            });

            await schoolMealsOrderingSystemDbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<ChildViewModel>> GetAllAsync()
        {
            var entities = await schoolMealsOrderingSystemDbContext
                .Children
                .Include(c => c.SchoolUser)
                .ToListAsync();

            return entities
                .Select(ch => new ChildViewModel
                {
                    Id = ch.Id,
                    FirstName = ch.FirstName,
                    LastName = ch.LastName,
                    Age = ch.Age,
                    School = ch.SchoolUser.SchoolName
                });
        }
    }
}
