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
                .ParentUsers
                .Where(pu => pu.Id == userId)
                .Include(pu => pu.ParentsChildren)
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
                SchoolUserId = AddChildViewModel.SchoolUserId,
                ParentChildRelation = AddChildViewModel.RelationToChild
            };


            child.ParentsChildren.Add(new ParentChild
            {
                Child = child,
                ParentUser = user,
            });

            await schoolMealsOrderingSystemDbContext.Children.AddAsync(child);


            await schoolMealsOrderingSystemDbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<ChildViewModel>> GetAllMyChildrenAsync(string userId)
        {

            var parent = await schoolMealsOrderingSystemDbContext
                .ParentUsers
                .Where(pu => pu.Id == userId)
                .Include(pu => pu.ParentsChildren)
                .ThenInclude(pu => pu.Child)
                .Include(pu => pu.ParentsChildren)
                .ThenInclude(pu => pu.Child.SchoolUser)
                .FirstAsync();

            Console.WriteLine();


            var result = parent
                .ParentsChildren
                .Select(pc => new ChildViewModel
                {
                    Id = pc.Child.Id,
                    FirstName = pc.Child.FirstName,
                    LastName = pc.Child.LastName,
                    Age = pc.Child.Age,
                    School = pc.Child?.SchoolUser?.SchoolName
                });

            Console.WriteLine();

            return result;
        }
    }
}
