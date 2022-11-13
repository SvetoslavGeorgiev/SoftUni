namespace SchoolMealsOrderingSystem.Core.Contracts
{
    using SchoolMealsOrderingSystem.Core.Models.Child;
    using SchoolMealsOrderingSystem.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ISchoolServices
    {
        Task<IEnumerable<SchoolUser>> GetSchoolsAsync();

        Task<IEnumerable<ChildViewModel>> GetAllChildrenInSelectedSchoolAsync(string schoolUserId);

    }
}
