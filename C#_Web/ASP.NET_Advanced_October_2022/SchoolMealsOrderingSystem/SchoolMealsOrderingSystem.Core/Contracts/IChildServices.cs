namespace SchoolMealsOrderingSystem.Core.Contracts
{
    using SchoolMealsOrderingSystem.Core.Models.Child;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IChildServices
    {

        Task<IEnumerable<ChildViewModel>> GetAllMyChildrenAsync(string userId);

        Task AddChildAsync(AddChildViewModel AddChildViewModel, string userId);


    }
}
