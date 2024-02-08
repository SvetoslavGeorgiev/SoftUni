namespace SchoolMealsOrderingSystem.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using SchoolMealsOrderingSystem.Core.Contracts;
    using SchoolMealsOrderingSystem.Core.Models.Child;
    using SchoolMealsOrderingSystem.Data;
    using SchoolMealsOrderingSystem.Data.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static Data.Constants.ParentUserConstants;
    using static Data.Constants.ChildConstants;

    public class ChildServices : IChildServices
    {
        private readonly SchoolMealsOrderingSystemDbContext schoolMealsOrderingSystemDbContext;

        public ChildServices(SchoolMealsOrderingSystemDbContext _schoolMealsOrderingSystemDbContext)
        {
            schoolMealsOrderingSystemDbContext = _schoolMealsOrderingSystemDbContext;
        }

        public async Task AddChildAsync(AddChildViewModel addChildViewModel, string userId, string imageUrl)
        {
            var user = await schoolMealsOrderingSystemDbContext
                .ParentUsers
                .Where(pu => pu.Id == userId && !pu.IsDeleted)
                .Include(pu => pu.ParentsChildren)
                .FirstOrDefaultAsync();


            if (user == null)
            {
                throw new ArgumentException(InvalidParentUserId);
            }


            var child = new Child()
            {
                FirstName = addChildViewModel.FirstName,
                LastName = addChildViewModel.LastName,
                Birthday = addChildViewModel.Birthday,
                SchoolUserId = addChildViewModel.SchoolUserId,
                ParentChildRelation = addChildViewModel.RelationToChild,
                ImageUrl = imageUrl,
                YearInSchool = addChildViewModel.YearInSchool
            };


            child.ParentsChildren.Add(new ParentChild
            {
                Child = child,
                ParentUser = user,
            });

            await schoolMealsOrderingSystemDbContext.Children.AddAsync(child);

            await schoolMealsOrderingSystemDbContext.SaveChangesAsync();

        }

        public async Task DeleteChildAsync(Guid childId)
        {
            var child = await schoolMealsOrderingSystemDbContext
                .Children
                .Where(c => c.Id == childId && !c.IsDeleted)
                .FirstOrDefaultAsync();

            if (child != null)
            {
                child.IsDeleted = true;

                await schoolMealsOrderingSystemDbContext.SaveChangesAsync();
            }
        }

        public async Task EditChildAsync(EditChildViewModel editChildViewModel)
        {

            var child = await schoolMealsOrderingSystemDbContext
                .Children
                .FindAsync(editChildViewModel.Id);

            if (child != null)
            {
                child.FirstName = editChildViewModel.FirstName;
                child.LastName = editChildViewModel.LastName;
                child.Birthday = editChildViewModel.Birthday;
                child.SchoolUserId = editChildViewModel.SchoolUserId;
                child.ParentChildRelation = editChildViewModel.RelationToChild;
                child.YearInSchool = editChildViewModel.YearInSchool;
            }

            await schoolMealsOrderingSystemDbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<ChildViewModel>> GetAllMyChildrenAsync(string userId)
        {

            var parent = await schoolMealsOrderingSystemDbContext
                .ParentUsers
                .Where(pu => pu.Id == userId && !pu.IsDeleted)
                .Include(pu => pu.ParentsChildren)
                .ThenInclude(pu => pu.Child)
                .Include(pu => pu.ParentsChildren.Where(pc => pc.Child.IsDeleted == false))
                .ThenInclude(pu => pu.Child.SchoolUser)
                .FirstAsync();


            var result = parent
                .ParentsChildren
                .OrderBy(pc => pc.Child.FirstName)
                .ThenBy(pc => pc.Child.LastName)
                .Select(pc => new ChildViewModel()
                {
                    Id = pc.Child.Id,
                    FirstName = pc.Child.FirstName,
                    LastName = pc.Child.LastName,
                    YearsOld = pc.Child.YearsOld,
                    MonthsOld = pc.Child.Months == 12 ? 0 : pc.Child.Months,
                    ImageUrl = pc.Child.ImageUrl,
                    YearInSchool = pc.Child.YearInSchool,
                    School = pc.Child.SchoolUser!.SchoolName == string.Empty ? DeletedSchoolUser : pc.Child.SchoolUser.SchoolName
                });


            return result;
        }

        public async Task<ChildViewModel> GetChildByIdAsync(Guid childId)
        {
            var child = await schoolMealsOrderingSystemDbContext
                .Children
                .Where(c => c.Id.Equals(childId) && !c.IsDeleted)
                .Select(c => new ChildViewModel
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    YearsOld = c.YearsOld,
                    ImageUrl= c.ImageUrl,
                    MonthsOld = c.Months == 12 ? 0 : c.Months,
                    YearInSchool = c.YearInSchool,
                    School = c.SchoolUser!.SchoolName == string.Empty ? DeletedSchoolUser : c.SchoolUser.SchoolName

                }).FirstOrDefaultAsync();


            return child!;
        }

        public async Task<EditChildViewModel> GetChildModelForEditAsync(Guid childId)
        {

            var child = await schoolMealsOrderingSystemDbContext
                .Children
                .Where(c => c.Id.Equals(childId) && !c.IsDeleted)
                .Select(c => new EditChildViewModel
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Birthday = c.Birthday,
                    RelationToChild = c.ParentChildRelation,
                    YearInSchool = c.YearInSchool
                })
                .SingleOrDefaultAsync();

            if (child == null)
            {
                throw new ArgumentException(InvalidChildUserId);
            }

            return child;
        }



    }
}
