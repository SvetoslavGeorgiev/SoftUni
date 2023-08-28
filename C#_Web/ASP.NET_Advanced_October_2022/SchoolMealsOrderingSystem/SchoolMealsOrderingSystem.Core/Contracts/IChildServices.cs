namespace SchoolMealsOrderingSystem.Core.Contracts
{
    using Models.Child;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IChildServices
    {

        Task<IEnumerable<ChildViewModel>> GetAllMyChildrenAsync(string userId);

        Task AddChildAsync(AddChildViewModel addChildViewModel, string userId);
        Task EditChildAsync(EditChildViewModel editChildViewModel);

        Task<EditChildViewModel> GetChildModelForEditAsync(Guid childId);

        Task DeleteChildAsync(Guid childId);
        Task<ChildViewModel> GetChildByIdAsync(Guid childId);
    }
}
