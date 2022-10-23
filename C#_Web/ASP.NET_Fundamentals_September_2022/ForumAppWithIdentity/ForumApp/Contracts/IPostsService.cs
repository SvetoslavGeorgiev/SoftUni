namespace ForumApp.Contracts
{
    using ForumApp.Models;
    using Microsoft.AspNetCore.Mvc;

    public interface IPostsService
    {

        Task<IEnumerable<PostViewModel>> GetAllAsync(string userId);

        Task<PostViewModel> GetModelForEditAsync(int id);

        Task AddAsync(PostViewModel model, string userId);

        Task EditAsync(PostViewModel model);

        Task DeleteAsync(int id);

    }
}
