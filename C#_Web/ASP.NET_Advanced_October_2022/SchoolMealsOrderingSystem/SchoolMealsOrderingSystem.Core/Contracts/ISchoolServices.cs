namespace SchoolMealsOrderingSystem.Core.Contracts
{
    using Models.Child;
    using Data.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISchoolServices
    {
        Task<IEnumerable<SchoolUser>> GetSchoolsAsync();

        Task<IEnumerable<ChildViewModel>> GetAllChildrenInSelectedSchoolAsync(string schoolUserId);

    }
}
